using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
using NetFwTypeLib;
using Newtonsoft.Json;
using QQWry;

namespace WinIpBan
{
    public delegate void SeedMessage(string requestInfo);
    public class Helper
    {
        public static SeedMessage SeedMessage;
        public static List<Model> Models { get; set; }= new List<Model>();

        public static Config config = new Config();

        public static void Init()
        {
            if (File.Exists("config.json"))
            {
                try
                {
                    config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json"));
                }
                catch (Exception e)
                {
                   
                }
               
            }
            if (File.Exists("history"))
            {
                try
                {
                    Models = JsonConvert.DeserializeObject<List<Model>>(File.ReadAllText("history"));
                    foreach (var m in Models)
                    {
                        //初始化
                        m.Limits = new Limits(config.limit, config.intervalSeconds);
                    }
                }
                catch (Exception e)
                {

                }
            }
            var msg = "";
           // OpenFw();
            GetRuleAddress(out msg);
            if (!string.IsNullOrEmpty(msg))
            {
                CreateRule();
            }
            Task.Factory.StartNew(GetAllActive);
            Task.Factory.StartNew(RemoveElapsed);
            Task.Factory.StartNew(RemoveActiveTimeout);
        }

        private static void RemoveActiveTimeout()
        {
            while (true)
            {
                //获取所有不活动的
                var list = Models.Where(n => n.lastActiveDate.AddSeconds(config.activeTimeout) < DateTime.Now&&n.state==1);
                if (list.Any())
                {
                    foreach (var model in list)
                    {
                        Models.Remove(model);
                    }
                }
                Thread.Sleep(5000);
            }
        }

        public static void OpenFw()
        {
            var registryKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion");
            var versionName = registryKey.GetValue("ProductName").ToString();
            registryKey.Close();
           // RegistryKey key;
            var serviceName = "";
            if (versionName.Contains("XP"))
            {
                serviceName = "SharedAccess";
               // key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\SharedAccess", true);
            }
            else
            {
                serviceName = "MpsSvc";
               // key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\MpsSvc", true);
            }

            //var startIndex = key.GetValue("Start").ToString();
            ////判断防火墙状态，如果开始是关闭的时候则放行所有端口，
            ////如果是打开状态，则不做操作。
            //if (startIndex == "4")
            //{
            //    var processStartInfo = new ProcessStartInfo
            //    {
            //        FileName = "cmd.exe",
            //        CreateNoWindow = false,
            //        WindowStyle = ProcessWindowStyle.Hidden,
            //        Arguments = "/c sc config " + serviceName + " start= " + "auto"
            //    };
            //    Process.Start(processStartInfo);
            //    Thread.Sleep(1000);
            //}

           // key.Close();
            var sc = new ServiceController(serviceName);
            if (sc.Status.Equals(ServiceControllerStatus.Stopped) ||
                sc.Status.Equals(ServiceControllerStatus.StopPending))
            {
                sc.Start();
                Thread.Sleep(1000);
            }
            CheckRdpPort();
            if (versionName.Contains("XP"))
            {
                var rk = Registry.LocalMachine.OpenSubKey(
                    @"SYSTEM\CurrentControlSet\Services\SharedAccess\Parameters\FirewallPolicy\StandardProfile", true);
                var enableFirewall = rk.GetValue("EnableFirewall").ToString();
                if (enableFirewall == "0") rk.SetValue("EnableFirewall", 1);
                rk.Close();
            }
            else
            {
                var firewallPolicy =
                    (INetFwPolicy2) Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                firewallPolicy.FirewallEnabled[NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PRIVATE] = true;
                firewallPolicy.FirewallEnabled[NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PUBLIC] = true;
                firewallPolicy.FirewallEnabled[NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_DOMAIN] = true;
            }
            
        }

        private static void CheckRdpPort()
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"System\CurrentControlSet\Control\Terminal Server\WinStations\RDP-Tcp", false))
            {
                if (key is null)
                {
                    
                }
                else
                {
                    int port = (int)key.GetValue("PortNumber", 3389);
                    OpenPort(port);
                }
              
            }
        }

        public static void OpenPort(int port)
        {
            var policy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            var rule = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwRule"));
            rule.Name = "openport" + port;
            rule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
            rule.Protocol = (int)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
            rule.LocalPorts = port.ToString();
            rule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
            rule.InterfaceTypes = "All";
            rule.Enabled = true;
            try
            {
                policy2.Rules.Add(rule);
            }
            catch (Exception e)
            {
            }
        }


        public static void CreateRule(string address="")
        {
            var policy2 = (INetFwPolicy2) Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            var rule = (INetFwRule) Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwRule"));
            rule.Name = config.ruleName;
            rule.Description = "ipban";
            rule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
            rule.Protocol = (int) NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_ANY;
            //rule.RemoteAddresses = address;
            rule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            rule.Enabled = false;
            try
            {
                
                policy2.Rules.Add(rule);
            }
            catch (Exception e)
            {
            }
        }

        public static void WriteConfig()
        {
            File.WriteAllText("config.json",JsonConvert.SerializeObject(config));
        }


        public static void DeleteRule()
        {
            var policy2 = (INetFwPolicy2) Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            try
            {
                policy2.Rules.Remove(config.ruleName);
            }
            catch (Exception e)
            {
            }
        }


        public static void UpdateRule(string address)
        {
         
            var policy2 = (INetFwPolicy2) Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            try
            {

                var rule = policy2.Rules.Item(config.ruleName);
                rule.RemoteAddresses = address;
                if (string.IsNullOrEmpty(address)|| address== "*" || address.Contains("*,"))
                {
                    rule.Enabled = false;
                }
                else
                {
                    rule.Enabled = true;
                }
            }
            catch (Exception e)
            {
            }
        }

        public static string GetRuleAddress(out string msg)
        {
            msg = "";
            var policy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            try
            {
                var rule = policy2.Rules.Item(config.ruleName);

                if (rule.Enabled)
                {
                    return rule.RemoteAddresses;
                }
                else
                {
                    return "";
                }
                
            }
            catch (Exception e)
            {
                msg = "not found";
            }

            return "";
        }

        public static void GetAllActive()
        {
            //加载ip
            QQWryIpSearch ipSearch;
            try
            {
                 ipSearch = new QQWryIpSearch(new QQWryOptions()
                {
                    DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "qqwry.dat")
                });
                var pre = ipSearch.GetIpLocation("8.8.8.8");
             
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
            while (true)
            {
                var properties = IPGlobalProperties.GetIPGlobalProperties();
                var ports = config.ports.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                var connections = properties.GetActiveTcpConnections()
                    .Where(n => ports.Contains(n.LocalEndPoint.Port.ToString()));
                var banList = new List<string>();
                foreach (var c in connections)
                {
                    var remoteIp = c.RemoteEndPoint.Address.ToString();
                    var whiteList = config.whiteList.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if(whiteList.Contains(remoteIp)) continue;
                    var model = Models.FirstOrDefault(n =>
                        n.ip == remoteIp && n.localPort == c.LocalEndPoint.Port);
                    if (model == null)
                    {
                        var address = "未知";
                        try
                        {
                            var ipLocation = ipSearch.GetIpLocation(remoteIp);
                             address = ipLocation.Country + ipLocation.Area;
                        }
                        catch (Exception e)
                        {
                            
                        }

                        var newmodel = new Model
                        {
                            ip = remoteIp,
                            localPort = c.LocalEndPoint.Port,
                            remotePort = c.RemoteEndPoint.Port,
                            Limits = new Limits(config.limit, config.intervalSeconds),
                            address = address

                        };
                        newmodel.Limits.Check();
                        Models.Add(newmodel);
                        SeedMessage?.Invoke(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+" 【"+ remoteIp + "】" + "加入监控");
                    }
                    else
                    {
                        if (model.remotePort == c.RemoteEndPoint.Port || model.state != 0) continue;
                        if (model.Limits == null) continue;
                        model.remotePort = c.RemoteEndPoint.Port;
                        model.totalCount++;
                        model.lastActiveDate=DateTime.Now;
                        if (model.Limits.Check()) continue;
                        model.state = 1;
                        model.elapsedTime=DateTime.Now.AddSeconds(config.elapsedSeconds);
                        banList.Add(model.ip);
                    }
                }
                BanAddress(banList);
                Thread.Sleep(500);
            }
        }

        public static void BanAddress(List<string> banList)
        {
            if(banList==null ||!banList.Any()){return;}
            var address = GetRuleAddress(out _);
            var list = address.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
            var tempList = new List<string>();
            if (list.Any())
            {
                tempList.AddRange(list.Select(l => l.Replace("/255.255.255.255", "")));
            }
            var realList = tempList.Union(banList).Distinct();
            if (realList.Any())
            {
                UpdateRule(string.Join(",", realList));
            }
            //日志
            foreach (var ban in banList)
            {
                SeedMessage?.Invoke(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 【" + ban + "】" + "封禁");
            }

          
        }

        public static void WriteWhiteList(string address)
        {
            if(string.IsNullOrEmpty(address)) return;
            var addresses = address.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            if (addresses.Any())
            {
                var ruleAddress = GetRuleAddress(out _);
                if (string.IsNullOrEmpty(ruleAddress))
                {
                    return;
                }
                var ruleAddressList = ruleAddress.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();
                var tempList = new List<string>();
                if (ruleAddressList.Any())
                {
                    tempList.AddRange(ruleAddressList.Select(l => l.Replace("/255.255.255.255", "")));
                }
                var newList = tempList.Intersect(addresses.Distinct());
                if (newList.Any())
                {
                    foreach (var nl in newList)
                    {
                        ruleAddressList.Remove(nl);
                    }

                    if (ruleAddressList.Any())
                    {
                        UpdateRule(string.Join(",", ruleAddressList));
                    }
                    
                }
            }
        }

        public static void RemoveElapsed()
        {
            while (true)
            {
                //获取所有过期的
                var now = DateTime.Now;
                var list= Models.Where(n => n.elapsedTime <= now && n.state == 1);
                if (list.Any())
                {
                    foreach (var l in list)
                    {
                        l.state = 0;
                        l.elapsedTime = null;
                    }
                    var ips = list.Select(n => n.ip).ToList();
                    var address = GetRuleAddress(out _);
                    var banList = address.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    var tempList = new List<string>();
                    if (banList.Any())
                    {
                        tempList.AddRange(banList.Select(l => l.Replace("/255.255.255.255", "")));
                    }
                    foreach (var ip in ips)
                    {
                        try
                        {
                            tempList.Remove(ip);
                            //日志
                            SeedMessage?.Invoke(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 【" + ip + "】" + "解封");
                            
                        }
                        catch (Exception e)
                        {
                           
                        }
                      
                    }

                    if (tempList.Any())
                    {
                        UpdateRule(string.Join(",", tempList));
                    }
                  
                }
                Thread.Sleep(10000);
            }
        }

    }

    public class Limits
    {
        private readonly int _intervalSeconds;
        private readonly int _limit;
        private readonly object lockObj = new object();
        private int _count;
        private int _prevCount;

        private DateTime _startTime;

        public Limits(int limit, int intervalSeconds)
        {
            _startTime = DateTime.Now;
            _limit = limit;
            _intervalSeconds = intervalSeconds;
        }

        public bool Check()
        {
            var currentDateTime = DateTime.Now;
            lock (lockObj)
            {
                var elapsedSeconds = (currentDateTime - _startTime).TotalSeconds;
                if (elapsedSeconds >= _intervalSeconds * 2) //间隔两次以上重置
                {
                    _startTime = currentDateTime;
                    _prevCount = 0;
                    _count = 0;
                    elapsedSeconds = 0;
                }
                else if (elapsedSeconds >= _intervalSeconds)
                {
                    _startTime = _startTime.AddSeconds(_intervalSeconds);
                    _prevCount = _count;
                    _count = 0;
                    elapsedSeconds = (currentDateTime - _startTime).TotalSeconds;
                }
                var count = _prevCount * (1 - elapsedSeconds / _intervalSeconds) + _count + 1;
                if (!(count <= _limit)) return false;
                _count++;
                return true;
            }

        }
    }

    public class Model
    {
        public string ip { get; set; }
        public int totalCount { get; set; } = 1;
        
        public int localPort { get; set; }

        public int remotePort { get; set; }
        
        public string address { get; set; } = "";

        public int state { get; set; } = 0;

        public DateTime lastActiveDate { get; set; }=DateTime.Now;

        public DateTime? elapsedTime { get; set; } 
        [JsonIgnoreAttribute]
        public string elapsedTimeStr => state == 1 ? elapsedTime?.ToString("yyyy-MM-dd HH:mm:ss") : "";
        [JsonIgnoreAttribute]
        public Limits Limits;
    }
   
    public class Config
    {
        public int intervalSeconds { get; set; } = 60;
        public string ports { get; set; } = "3389";
        public int limit { get; set; } = 5;
        public string whiteList { get; set; } = "";
        public int elapsedSeconds { get; set; } = 36000;

        public string ruleName { get; set; } = "ipban_win";

        public int activeTimeout { get; set; } = 180;
    }
}