// See https://aka.ms/new-console-template for more information
using System.Text;
using Xelit3.Playground.Hmac.Client;


var clientId = "ClientId1";
var secretKey = "SecretKey1";
var baseUrl = "https://localhost:7011/api/Employees";

using var client = new HttpClient();

// Create an Employee
var employee = new
{
    Name = "Pranaya Rout",
    Position = "Developer",
    Salary = 60000
};

var requestBody = System.Text.Json.JsonSerializer.Serialize(employee);
var token = HMACHelper.GenerateHmacToken("POST", "/api/employees", clientId, secretKey, requestBody);

var requestMessage = new HttpRequestMessage(HttpMethod.Post, baseUrl)
{
    Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
};
requestMessage.Headers.Add("Authorization", $"HMAC {token}");

var response = await client.SendAsync(requestMessage);
var responseContent = await response.Content.ReadAsStringAsync();
Console.WriteLine($"POST Response: {responseContent}");

// Get all Employees
token = HMACHelper.GenerateHmacToken("GET", "/api/employees", clientId, secretKey);

requestMessage = new HttpRequestMessage(HttpMethod.Get, baseUrl);
requestMessage.Headers.Add("Authorization", $"HMAC {token}");

response = await client.SendAsync(requestMessage);
responseContent = await response.Content.ReadAsStringAsync();
Console.WriteLine($"GET Response: {responseContent}");

// Assuming the created employee has an ID of 1 (adjust as necessary)

// Get Employee by ID
var employeeId = 1;
var getByIdUrl = $"{baseUrl}/{employeeId}";

token = HMACHelper.GenerateHmacToken("GET", $"/api/employees/{employeeId}", clientId, secretKey);

requestMessage = new HttpRequestMessage(HttpMethod.Get, getByIdUrl);
requestMessage.Headers.Add("Authorization", $"HMAC {token}");

response = await client.SendAsync(requestMessage);
responseContent = await response.Content.ReadAsStringAsync();
Console.WriteLine($"GET by ID Response: {responseContent}");

// Update Employee
var updatedEmployee = new
{
    Id = employeeId,
    Name = "Rakesh Sharma",
    Position = "Senior Developer",
    Salary = 80000
};
requestBody = System.Text.Json.JsonSerializer.Serialize(updatedEmployee);
token = HMACHelper.GenerateHmacToken("PUT", $"/api/employees/{employeeId}", clientId, secretKey, requestBody);

requestMessage = new HttpRequestMessage(HttpMethod.Put, getByIdUrl)
{
    Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
};
requestMessage.Headers.Add("Authorization", $"HMAC {token}");

response = await client.SendAsync(requestMessage);
responseContent = await response.Content.ReadAsStringAsync();
Console.WriteLine($"PUT Response: {responseContent}");

// Delete Employee
token = HMACHelper.GenerateHmacToken("DELETE", $"/api/employees/{employeeId}", clientId, secretKey);

requestMessage = new HttpRequestMessage(HttpMethod.Delete, getByIdUrl);
requestMessage.Headers.Add("Authorization", $"HMAC {token}");

response = await client.SendAsync(requestMessage);
responseContent = await response.Content.ReadAsStringAsync();
Console.WriteLine($"DELETE Response: {responseContent}");

Console.ReadKey();