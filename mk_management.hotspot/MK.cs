using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace mk_management.hotspot
{
    public class MK
    {
        Stream connection;
        TcpClient con;

        string version = "6.43";
        internal string allSupportedVersion = "6.43,6.45.1";

        internal readonly string[] AllVersions;

        public MK()
        {
            AllVersions = allSupportedVersion.Split(',');
        }

        public MK(string ip, int port, string versionOS)
        {
            version = versionOS;
            AllVersions = allSupportedVersion.Split(',');

            con = new TcpClient();
            //con.NoDelay = true;
            con.Connect(ip, port);
            //con.Connect(ip, 8728);
            connection = (Stream)con.GetStream();
        }

        public void Close()
        {
            try
            {
                connection.Close();
                con.Close();
            }
            catch
            {
            }
        }

        public void Send(string co)
        {
            Send(co, false);
        }

        public void Send(string co, bool endsentence)
        {
            byte[] bajty = Encoding.ASCII.GetBytes(co.ToCharArray());
            byte[] velikost = EncodeLength(bajty.Length);
            connection.Write(velikost, 0, velikost.Length);
            connection.Write(bajty, 0, bajty.Length);
            if (endsentence)
            {
                connection.WriteByte(0);
            }
        }

        public List<string> Read()
        {
            List<string> output = new List<string>();
            string o = "";
            byte[] tmp = new byte[4];
            long count;
            while (true)
            {
                tmp[3] = (byte)connection.ReadByte();
                //if(tmp[3] == 220) tmp[3] = (byte)connection.ReadByte(); it sometimes happend to me that 
                //mikrotik send 220 as some kind of "bonus" between words, this fixed things, not sure about it though
                if (tmp[3] == 0)
                {
                    output.Add(o);
                    if (o.Substring(0, 5) == "!done")
                    {
                        break;
                    }
                    else
                    {
                        o = "";
                        continue;
                    }
                }
                else
                {
                    if (tmp[3] < 0x80)
                    {
                        count = tmp[3];
                    }
                    else
                    {
                        if (tmp[3] < 0xC0)
                        {
                            int tmpi = BitConverter.ToInt32(new byte[] { (byte)connection.ReadByte(), tmp[3], 0, 0 }, 0);
                            count = tmpi ^ 0x8000;
                        }
                        else
                        {
                            if (tmp[3] < 0xE0)
                            {
                                tmp[2] = (byte)connection.ReadByte();
                                int tmpi = BitConverter.ToInt32(new byte[] { (byte)connection.ReadByte(), tmp[2], tmp[3], 0 }, 0);
                                count = tmpi ^ 0xC00000;
                            }
                            else
                            {
                                if (tmp[3] < 0xF0)
                                {
                                    tmp[2] = (byte)connection.ReadByte();
                                    tmp[1] = (byte)connection.ReadByte();
                                    int tmpi = BitConverter.ToInt32(new byte[] { (byte)connection.ReadByte(), tmp[1], tmp[2], tmp[3] }, 0);
                                    count = tmpi ^ 0xE0000000;
                                }
                                else
                                {
                                    if (tmp[3] == 0xF0)
                                    {
                                        tmp[3] = (byte)connection.ReadByte();
                                        tmp[2] = (byte)connection.ReadByte();
                                        tmp[1] = (byte)connection.ReadByte();
                                        tmp[0] = (byte)connection.ReadByte();
                                        count = BitConverter.ToInt32(tmp, 0);
                                    }
                                    else
                                    {
                                        //Error in packet reception, unknown length
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < count; i++)
                {
                    o += (Char)connection.ReadByte();
                }
            }
            return output;
        }

        byte[] EncodeLength(int delka)
        {
            if (delka < 0x80)
            {
                byte[] tmp = BitConverter.GetBytes(delka);
                return new byte[1] { tmp[0] };
            }
            if (delka < 0x4000)
            {
                byte[] tmp = BitConverter.GetBytes(delka | 0x8000);
                return new byte[2] { tmp[1], tmp[0] };
            }
            if (delka < 0x200000)
            {
                byte[] tmp = BitConverter.GetBytes(delka | 0xC00000);
                return new byte[3] { tmp[2], tmp[1], tmp[0] };
            }
            if (delka < 0x10000000)
            {
                byte[] tmp = BitConverter.GetBytes(delka | 0xE0000000);
                return new byte[4] { tmp[3], tmp[2], tmp[1], tmp[0] };
            }
            else
            {
                byte[] tmp = BitConverter.GetBytes(delka);
                return new byte[5] { 0xF0, tmp[3], tmp[2], tmp[1], tmp[0] };
            }
        }

        public string EncodePassword(string Password, string hash)
        {
            byte[] hash_byte = new byte[hash.Length / 2];
            for (int i = 0; i <= hash.Length - 2; i += 2)
            {
                hash_byte[i / 2] = Byte.Parse(hash.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
            }
            byte[] heslo = new byte[1 + Password.Length + hash_byte.Length];
            heslo[0] = 0;
            Encoding.ASCII.GetBytes(Password.ToCharArray()).CopyTo(heslo, 1);
            hash_byte.CopyTo(heslo, 1 + Password.Length);

            Byte[] hotovo;
            System.Security.Cryptography.MD5 md5;

            md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            hotovo = md5.ComputeHash(heslo);

            //Convert encoded bytes back to a 'readable' string
            string navrat = "";
            foreach (byte h in hotovo)
            {
                navrat += h.ToString("x2");
            }
            return navrat;
        }

        public string AddProfile(string name, int upRate_kb, int downRate_kb, int upTime_min, string transparentProxy = "yes")
        {
            var defineRate = true;
            var defineTime = true;
            var defineUsers = true;

            if (upRate_kb <= 0)
                defineRate = false;

            if (downRate_kb <= 0)
                defineRate = false;

            if (upTime_min <= 0)
                defineTime = false;

            name = name.Trim();
            Send("/ip/hotspot/user/profile/add", false);

            Send("=name=" + name, false);

            if (defineRate)
            {
                var rate = "=rate-limit=" + upRate_kb + "k/" + downRate_kb + "k";
                Send(rate, false);
            }

            if (defineTime)
            {
                var time = "=session-timeout=" + upTime_min * 60 + "s";
                Send(time, false);
            }

            if (defineUsers)
            {
                var users = "=shared-users=" + 1;
                Send(users, false);
            }

            Send("=transparent-proxy=" + transparentProxy, true);

            var resultado = Read();

            if (resultado.Count > 0)
            {
                if (hotspot.Helper.ProcesoMK_TieneErrores(resultado.ToArray()))
                {
                    var errores = hotspot.Helper.ProcesoMK_ObtenerErrores(resultado.ToArray());
                    common.Utilerias.msjAlert("No se pudo crear el perfil. Error : " + Environment.NewLine + Environment.NewLine + errores);
                    return "";
                }

                var resp = hotspot.Helper.ObtenerUltimoValorArreglo_Str(resultado.ToArray());

                if (hotspot.Helper.ProcesoMK_OK(resp))
                {
                    if (resp.Contains("ret="))
                        return resp.Replace("ret=", "");
                    else
                    {
                        mk_management.common.Utilerias.msjAlert("No se pudo crear el perfil. Error desconocido.");
                        return "";
                    }
                }
                else
                {
                    mk_management.common.Utilerias.msjAlert("No se pudo crear el usuario. Error : " + resultado[0]);
                }
            }

            return "";
        }

        public string AddUser(string user, string pass, int seconds, string profile)
        {
            pass = pass.Trim();

            if (common.Utilerias.IsNullOrEmpty(profile))
                profile = "default";

            Send("/ip/hotspot/user/add", false);
            Send("=name=" + user, false);
            Send("=password=" + pass, false);
            Send("=limit-uptime=" + seconds, false);
            //Send("=comment=" + comment, true);
            Send("=profile=" + profile, true);

            var resultado = Read();

            if (resultado.Count > 0)
            {
                if (hotspot.Helper.ProcesoMK_TieneErrores(resultado.ToArray()))
                {
                    var errores = hotspot.Helper.ProcesoMK_ObtenerErrores(resultado.ToArray());
                    mk_management.common.Utilerias.msjAlert("No se pudo crear el usuario. Error : " + Environment.NewLine + Environment.NewLine + errores);
                    return "";
                }

                var resp = hotspot.Helper.ObtenerUltimoValorArreglo_Str(resultado.ToArray());

                if (hotspot.Helper.ProcesoMK_OK(resp))
                {
                    if (resp.Contains("ret="))
                        return resp.Replace("ret=", "");
                    else
                    {
                        common.Utilerias.msjAlert("No se pudo crear el usuario. Error desconocido.");
                        return "";
                    }
                }
                else
                {
                    mk_management.common.Utilerias.msjAlert("No se pudo crear el usuario. Error : " + resultado[0]);
                }
            }

            return "";
        }

        public bool DeleteUser(string userId)
        {
            Send("/ip/hotspot/user/remove", false);
            Send("=.id=" + userId, true);

            var resultado = Read();

            if (resultado.Count > 0)
            {
                if (Helper.ProcesoMK_TieneErrores(resultado.ToArray()))
                {
                    var errores = Helper.ProcesoMK_ObtenerErrores(resultado.ToArray());
                    common.Utilerias.msjAlert("No se pudo eliminar el usuario. Error : " + Environment.NewLine + Environment.NewLine + errores);
                    return false;
                }

                var resp = Helper.ObtenerUltimoValorArreglo_Str(resultado.ToArray());

                if (Helper.ProcesoMK_OK(resp))
                {
                    return true;
                }
                else
                {
                    common.Utilerias.msjAlert("No se pudo eliminar el usuario. Error : " + resultado[0]);
                    return false;
                }
            }

            return false;
        }


        public bool ChangeUserStatus(string userId, string disabled)
        {

            if (disabled == "yes")
            {
                Send("/ip/hotspot/user/disable", false);
                Send("=.id=" + userId, true);
            }

            if (disabled == "no")
            {
                Send("/ip/hotspot/user/enable", false);
                Send("=.id=" + userId, true);
            }

            var resultado = Read();

            if (resultado.Count > 0)
            {
                if (Helper.ProcesoMK_TieneErrores(resultado.ToArray()))
                {
                    var errores = Helper.ProcesoMK_ObtenerErrores(resultado.ToArray());
                    common.Utilerias.msjAlert("No se pudo cambiar el estdo del usuario. Error : " + Environment.NewLine + Environment.NewLine + errores);
                    return false;
                }

                var resp = Helper.ObtenerUltimoValorArreglo_Str(resultado.ToArray());

                if (Helper.ProcesoMK_OK(resp))
                {
                    return true;
                }
                else
                {
                    common.Utilerias.msjAlert("No se pudo cambiar el estado del usuario. Error : " + resultado[0]);
                    return false;
                }
            }

            return false;
        }

        public string[] GetWifiInfo()
        {
            var list = new List<string>();
            Send("/system/identity/getall");
            Send(".tag=sss", true);

            var arr = Read();
            foreach (string h in arr)
            {
                list.Add(h);
            }

            return list.ToArray();
        }

        public string[] GetUsers()
        {
            var list = new List<string>();
            Send("/ip/hotspot/user/getall", true);

            var arr = Read();
            foreach (string h in arr)
            {
                list.Add(h);
            }

            return list.ToArray();
        }

        public string[] GetProfiles()
        {
            var list = new List<string>();      
            Send("/ip/hotspot/user/profile/getall", true);

            var arr = Read();
            foreach (string h in arr)
            {
                list.Add(h);
            }

            return list.ToArray();
        }


        public bool Login(string username, string password)
        {
            password = password.Trim();

            if (version == AllVersions[0]) //6.43
            {

                Send("/login", true);

                var _read = Read();

                if (_read == null || _read.Count() <= 0)
                {
                    return false;
                }

                string hash = _read[0].Split(new string[] { "ret=" }, StringSplitOptions.None)[1];
                Send("/login");
                Send("=name=" + username);
                Send("=response=00" + EncodePassword(password, hash), true);

                var resultado = Read();
                var resp = hotspot.Helper.ObtenerUltimoValorArreglo_StrList(resultado);

                //if (Read()[0] == "!done")
                if (hotspot.Helper.ProcesoMK_OK(resp))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (version == AllVersions[1]) //6.45.1
            {
                Send("/login");
                Send("=name=" + username);
                Send("=password=" + password, true);

                var resultado = Read();
                var resp = hotspot.Helper.ObtenerUltimoValorArreglo_StrList(resultado);

                //if (Read()[0] == "!done")
                if (hotspot.Helper.ProcesoMK_OK(resp))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

       

        public string[] getCPU_Usage()
        {
            var list = new List<string>();
            Send("/system/resource/cpu/getall", true);

            var arr = Read();
            foreach (string h in arr)
            {
                list.Add(h);
            }

            return list.ToArray();
        }


        public string[] getResource_info()
        {
            var list = new List<string>();
            Send("/system/resource/getall", true);

            var arr = Read();
            foreach (string h in arr)
            {
                list.Add(h);
            }

            return list.ToArray();
        }

        public string[] getDevices_Info()
        {
            var list = new List<string>();
            Send("/system/resource/getall", true);

            var arr = Read();
            foreach (string h in arr)
            {
                list.Add(h);
            }

            return list.ToArray();
        }

        public void reboot() => Send("/system/reboot", true);


        public string[] getCookies()
        {
            var list = new List<string>();
            Send("/ip/hotspot/cookie/getall", true);

            var arr = Read();
            foreach (string h in arr)
            {
                list.Add(h);
            }

            return list.ToArray();
        }

        public string[] removeCookie(int index)
        {
            var list = new List<string>();
            Send($"/ip/hotspot/cookie/remove", false);
            Send($"=.id={index}", true);

            var arr = Read();
            foreach (string h in arr)
            {
                list.Add(h);
            }

            return list.ToArray();
        }

        public string[] getActiveConnections()
        {
            var list = new List<string>();
            Send("/ip/hotspot/active/getall", true);

            var arr = Read();
            foreach (string h in arr)
            {
                list.Add(h);
            }

            return list.ToArray();
        }

        public string [] getServerProfiles()
        {
            var list = new List<string>();
            Send("/ip/hotspot/profile/getall", true);

            var arr = Read();
            foreach (string h in arr)
            {
                list.Add(h);
            }

            return list.ToArray();
        }
    }
}
