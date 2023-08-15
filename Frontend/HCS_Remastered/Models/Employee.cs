using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft;

namespace HCS_Remastered.Models
{
    internal class Employee
    {
        public uint? id { get; set; }
        public string? name { get; set; }
        public string? employeeType { get; set; }

        public async void Login(string password)
        {
            using (var client = new HttpClient())
            {
                //set up client
                client.BaseAddress = new Uri(Constants.API_ENDPOINT + "/Employees/Login");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string param = $"?id={this.id}";

                var response = await client.GetAsync(param);
                var result = await response.Content.ReadAsStringAsync();

                if (result != null)
                {
                    Employee employee = Newtonsoft.Json.JsonConvert.DeserializeObject<Employee>(result);
                    switch(employee.employeeType)
                    {
                        case "Staff":
                            break;
                        case "Nurse":
                            break;
                        case "Doctor":
                            break;
                        case "CEO":
                            break;
                    }
                }

                this.employeeType = result;
            }
        }

        public void Logout()
        {

        }
    }
}
