using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_11122019
{
    public class ReadConnectionString
    {
        public string ServerName { get; set; }

        public string DatabaseName { get; set; }
        public string Uid { get; set; }
        public string Pwd { get; set; }
        public bool WinNT { get; set; }
        public string ConnectionString { get; set; }
        public ReadConnectionString(string path)
        {
            DocChuoiKetNoiTuFile(path);
        }

        private void DocChuoiKetNoiTuFile(string path)
        {
            using(StreamReader sR = new StreamReader(path))
            {
                string line = string.Empty;
                while((line = sR.ReadLine()) != null)
                {
                    if(!string.IsNullOrEmpty(line))
                    {
                        switch (line.Substring(0, line.IndexOf('=')).Trim().ToLower())
                        {
                            case "server":
                                {
                                    ServerName = line.Substring(line.IndexOf('=') + 1);
                                    break;
                                }
                            case "database":
                                {
                                    DatabaseName = line.Substring(line.IndexOf('=') + 1);
                                    break;
                                }
                            case "uid":
                                {
                                    Uid = line.Substring(line.IndexOf('=') + 1);
                                    break;
                                }
                            case "pwd":
                                {
                                    Pwd = line.Substring(line.IndexOf('=') + 1);
                                    break;
                                }
                            case "winnt":
                                {
                                    WinNT = Convert.ToBoolean(line.Substring(line.IndexOf('=') + 1));
                                    break;
                                }
                            default:
                            break;
                        }
                    }
                }
                GhepChuoiKetNoi();
            }
        }

        private void GhepChuoiKetNoi()
        {
            if(WinNT)
            {
                ConnectionString = string.Format("server = {0}; database = {1}; integrated security = true;", ServerName, DatabaseName);
            }
            else
            {
                ConnectionString = string.Format("server = {0}; database = {1}; uid = {2}; pwd = {3};", ServerName, DatabaseName, Uid, Pwd);
            }
        }
        public void LuuChuoiKetNoiVaoFile(string path)
        {
            using(StreamWriter sW = new StreamWriter(path))
            {
                sW.WriteLine(string.Format("server = {0}", ServerName));
                sW.WriteLine(string.Format("database = {0}", DatabaseName));
                sW.WriteLine(string.Format("uid = {0}", Uid));
                sW.WriteLine(string.Format("pwd = {0}", Pwd));
                sW.Write(string.Format("winnt = {0}", WinNT.ToString()));
            }
        }
    }
}
