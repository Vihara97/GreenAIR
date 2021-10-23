using GreenAIR.MODELS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace GreenAIR
{
    public class WebApiCalls
    {

        #region User

        public List<UserModel> GetAllUsers()
        {
            List<UserModel> _oUserModel = new List<UserModel>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string path = "User/GetAllUsers";
                    client.BaseAddress = new Uri(GlobalValue.BaseUrl);

                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        _oUserModel = JsonConvert.DeserializeObject<List<UserModel>>(value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error is" + ex.ToString());
                throw ex;
            }
            return _oUserModel;
        }

        public UserModel GetUserById(int id)
        {
            UserModel _oUserModel = new UserModel();
            using (HttpClient client = new HttpClient())
            {
                string path = "User/GetUserById/" + id;
                client.BaseAddress = new Uri(GlobalValue.BaseUrl);

                HttpResponseMessage response = client.GetAsync(path).Result;
                if (response.IsSuccessStatusCode)
                {
                    var value = response.Content.ReadAsStringAsync().Result;
                    _oUserModel = JsonConvert.DeserializeObject<UserModel>(value);
                }
            }
            return _oUserModel;
        }

        public bool DeleteUserById(int id)
        {
            bool result = false;

            using (HttpClient client = new HttpClient())
            {
                string path = "User/DeleteUserById/" + id;
                client.BaseAddress = new Uri(GlobalValue.BaseUrl);

                HttpResponseMessage response = client.GetAsync(path).Result;
                if (response.IsSuccessStatusCode)
                {
                    var value = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<bool>(value);
                }
            }

            return result;
        }

        public bool AddUser(UserModel _user)
        {
            bool result = false;

            using (HttpClient client = new HttpClient())
            {
                string path = "User/AddUser";
                client.BaseAddress = new Uri(GlobalValue.BaseUrl);
                var json = JsonConvert.SerializeObject(_user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(path, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsnString = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<bool>(jsnString);
                }
            }

            return result;
        }

        public bool EditUser(UserModel _user)
        {
            bool result = false;
            using (HttpClient client = new HttpClient())
            {
                string path = "User/EditUser";
                client.BaseAddress = new Uri(GlobalValue.BaseUrl);
                var json = JsonConvert.SerializeObject(_user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(path, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsnString = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<bool>(jsnString);
                }
            }
            return result;
        }

        #endregion User

        #region Monitoring Center

        public List<MonitoringCenterModel> GetAllMonitoringCenters()
        {
            List<MonitoringCenterModel> _oMonitoringCenterModel = new List<MonitoringCenterModel>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string path = "MonitoringCenter/GetAllMonitoringCenters";
                    client.BaseAddress = new Uri(GlobalValue.BaseUrl);

                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        _oMonitoringCenterModel = JsonConvert.DeserializeObject<List<MonitoringCenterModel>>(value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error is" + ex.ToString());
                throw ex;
            }
            return _oMonitoringCenterModel;
        }

        public MonitoringCenterModel GetMonitoringCenterById(int id)
        {
            MonitoringCenterModel _oMonitoringCenterModel = new MonitoringCenterModel();
            using (HttpClient client = new HttpClient())
            {
                string path = "MonitoringCenter/GetMonitoringCenterById/" + id;
                client.BaseAddress = new Uri(GlobalValue.BaseUrl);

                HttpResponseMessage response = client.GetAsync(path).Result;
                if (response.IsSuccessStatusCode)
                {
                    var value = response.Content.ReadAsStringAsync().Result;
                    _oMonitoringCenterModel = JsonConvert.DeserializeObject<MonitoringCenterModel>(value);
                }
            }
            return _oMonitoringCenterModel;
        }

        public bool DeleteMonitoringCenterById(int id)
        {
            bool result = false;

            using (HttpClient client = new HttpClient())
            {
                string path = "MonitoringCenter/DeleteMonitoringCenterById/" + id;
                client.BaseAddress = new Uri(GlobalValue.BaseUrl);

                HttpResponseMessage response = client.GetAsync(path).Result;
                if (response.IsSuccessStatusCode)
                {
                    var value = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<bool>(value);
                }
            }

            return result;
        }

        public bool AddMonitoringCenter(MonitoringCenterModel _monitoringCenter)
        {
            bool result = false;

            using (HttpClient client = new HttpClient())
            {
                string path = "MonitoringCenter/AddMonitoringCenter";
                client.BaseAddress = new Uri(GlobalValue.BaseUrl);
                var json = JsonConvert.SerializeObject(_monitoringCenter);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(path, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsnString = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<bool>(jsnString);
                }
            }

            return result;
        }

        public bool EditMonitoringCenter(MonitoringCenterModel _monitoringCenter)
        {
            bool result = false;
            using (HttpClient client = new HttpClient())
            {
                string path = "MonitoringCenter/EditMonitoringCenter";
                client.BaseAddress = new Uri(GlobalValue.BaseUrl);
                var json = JsonConvert.SerializeObject(_monitoringCenter);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(path, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsnString = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<bool>(jsnString);
                }
            }
            return result;
        }

        #endregion Monitoring Center

        #region IOT Device

        public List<IOTDeviceModel> GetAllIOTDevices()
        {
            List<IOTDeviceModel> _oIOTDeviceModel = new List<IOTDeviceModel>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string path = "IOTDevice/GetAllIOTDevices";
                    client.BaseAddress = new Uri(GlobalValue.BaseUrl);

                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        _oIOTDeviceModel = JsonConvert.DeserializeObject<List<IOTDeviceModel>>(value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error is" + ex.ToString());
                throw ex;
            }
            return _oIOTDeviceModel;
        }

        public IOTDeviceModel GetIOTDeviceById(int id)
        {
            IOTDeviceModel _oIOTDeviceModel = new IOTDeviceModel();
            using (HttpClient client = new HttpClient())
            {
                string path = "IOTDevice/GetIOTDeviceById/" + id;
                client.BaseAddress = new Uri(GlobalValue.BaseUrl);

                HttpResponseMessage response = client.GetAsync(path).Result;
                if (response.IsSuccessStatusCode)
                {
                    var value = response.Content.ReadAsStringAsync().Result;
                    _oIOTDeviceModel = JsonConvert.DeserializeObject<IOTDeviceModel>(value);
                }
            }
            return _oIOTDeviceModel;
        }

        public bool DeleteIOTDeviceById(int id)
        {
            bool result = false;

            using (HttpClient client = new HttpClient())
            {
                string path = "IOTDevice/DeleteIOTDeviceById/" + id;
                client.BaseAddress = new Uri(GlobalValue.BaseUrl);

                HttpResponseMessage response = client.GetAsync(path).Result;
                if (response.IsSuccessStatusCode)
                {
                    var value = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<bool>(value);
                }
            }

            return result;
        }

        public bool AddIOTDevice(IOTDeviceModel _IOTDevice)
        {
            bool result = false;

            using (HttpClient client = new HttpClient())
            {
                string path = "IOTDevice/AddIOTDevice";
                client.BaseAddress = new Uri(GlobalValue.BaseUrl);
                var json = JsonConvert.SerializeObject(_IOTDevice);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(path, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsnString = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<bool>(jsnString);
                }
            }

            return result;
        }

        public bool EditIOTDevice(IOTDeviceModel _IOTDevice)
        {
            bool result = false;
            using (HttpClient client = new HttpClient())
            {
                string path = "IOTDevice/EditIOTDevice";
                client.BaseAddress = new Uri(GlobalValue.BaseUrl);
                var json = JsonConvert.SerializeObject(_IOTDevice);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(path, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsnString = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<bool>(jsnString);
                }
            }
            return result;
        }

        #endregion IOT Device

        #region Vegitation

        public List<VegitationModel> GetAllVegitations()
        {
            List<VegitationModel> _oVegitationModel = new List<VegitationModel>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string path = "Vegitation/GetAllVegitations";
                    client.BaseAddress = new Uri(GlobalValue.BaseUrl);

                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var value = response.Content.ReadAsStringAsync().Result;
                        _oVegitationModel = JsonConvert.DeserializeObject<List<VegitationModel>>(value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error is" + ex.ToString());
                throw ex;
            }
            return _oVegitationModel;
        }

        public VegitationModel GetVegitationById(int id)
        {
            VegitationModel _oVegitationModel = new VegitationModel();
            using (HttpClient client = new HttpClient())
            {
                string path = "Vegitation/GetVegitationById/" + id;
                client.BaseAddress = new Uri(GlobalValue.BaseUrl);

                HttpResponseMessage response = client.GetAsync(path).Result;
                if (response.IsSuccessStatusCode)
                {
                    var value = response.Content.ReadAsStringAsync().Result;
                    _oVegitationModel = JsonConvert.DeserializeObject<VegitationModel>(value);
                }
            }
            return _oVegitationModel;
        }

        public bool DeleteVegitationById(int id)
        {
            bool result = false;

            using (HttpClient client = new HttpClient())
            {
                string path = "Vegitation/DeleteVegitationById/" + id;
                client.BaseAddress = new Uri(GlobalValue.BaseUrl);

                HttpResponseMessage response = client.GetAsync(path).Result;
                if (response.IsSuccessStatusCode)
                {
                    var value = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<bool>(value);
                }
            }

            return result;
        }

        public bool AddVegitation(VegitationModel _Vegitation)
        {
            bool result = false;

            using (HttpClient client = new HttpClient())
            {
                string path = "Vegitation/AddVegitation";
                client.BaseAddress = new Uri(GlobalValue.BaseUrl);
                var json = JsonConvert.SerializeObject(_Vegitation);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(path, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsnString = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<bool>(jsnString);
                }
            }

            return result;
        }

        public bool EditVegitation(VegitationModel _Vegitation)
        {
            bool result = false;
            using (HttpClient client = new HttpClient())
            {
                string path = "Vegitation/EditVegitation";
                client.BaseAddress = new Uri(GlobalValue.BaseUrl);
                var json = JsonConvert.SerializeObject(_Vegitation);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(path, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsnString = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<bool>(jsnString);
                }
            }
            return result;
        }

        #endregion Vegitation
    }
}