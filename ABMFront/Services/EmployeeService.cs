using System;
using RestSharp;
using System.Collections.Generic;
using ABMFront.ViewModels;

namespace ABMFront.Services
{
    public class EmployeeService
    {
        public void CreateEmployee(EmployeeViewModel employee)
        {
            var client = new RestClient("http://localhost:5010/api/");
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            var request = new RestRequest("Employee", Method.POST);
            request.AddJsonBody(employee);
            var response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
        }

        public List<EmployeeViewModel> GetAllEmployees()
        {
            var client = new RestClient("http://localhost:5010/api/");
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            var response = client.Execute<List<EmployeeViewModel>>(new RestRequest("Employee"), Method.GET);
            return response.Data;
        }

        public EmployeeViewModel ShowEmployeeById(int idEmployee)
        {
            var client = new RestClient("http://localhost:5010/api/");
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            var response = client.Execute<EmployeeViewModel>(new RestRequest("Employee/" + idEmployee, Method.GET));
            return response.Data;
        }

        public void ModifyEmployee(EmployeeViewModel employee)
        {
            var client = new RestClient("http://localhost:5010/api/");
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            var request = new RestRequest("Employee/" + employee.ID, Method.PUT);
            request.AddJsonBody(employee);
            var response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
        }

        public void DeleteEmployee(EmployeeViewModel employee)
        {
            var client = new RestClient("http://localhost:5010/api/");
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            var request = new RestRequest("Employee/" + employee.ID, Method.DELETE);
            request.AddJsonBody(employee);
            var response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
        }
    }
}