using System;
using System.Threading.Tasks;
using System.Net.Http;
using Modul5HW1.Models;
using Newtonsoft.Json;

namespace Modul5HW1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var userClient = new UserClient();

            var res1 = await userClient.MakeResponse<ListResponse<User>>(HttpMethod.Get, "users?page=2");

            var res2 = await userClient.MakeResponse<SingleResponse<User>>(HttpMethod.Get, "users/2");

            var res3 = await userClient.MakeResponse<SingleResponse<User>>(HttpMethod.Get, "users/23");

            var res4 = await userClient.MakeResponse<ListResponse<Resource>>(HttpMethod.Get, "unknown");

            var res5 = await userClient.MakeResponse<SingleResponse<Resource>>(HttpMethod.Get, "unknown/2");

            var res6 = await userClient.MakeResponse<SingleResponse<Resource>>(HttpMethod.Get, "unknown/23");

            var obj7 = JsonConvert.SerializeObject(
                new
                {
                    name = "morpheus",
                    job = "leader"
                });
            var res7 = await userClient.MakeResponse<CreateResponse>(HttpMethod.Post, "users", obj7);

            var obj8 = JsonConvert.SerializeObject(
                new
                {
                    name = "morpheus",
                    job = "zion resident"
                });
            var res8 = await userClient.MakeResponse<UpdateResponse>(HttpMethod.Put, "users/2", obj8);

            var obj9 = JsonConvert.SerializeObject(
                new
                {
                    name = "morpheus",
                    job = "zion resident"
                });
            var res9 = await userClient.MakeResponse<UpdateResponse>(HttpMethod.Patch, "users/2", obj9);

            var res10 = await userClient.MakeResponse<DeleteResponse>(HttpMethod.Delete, "users/2");

            var obj11 = JsonConvert.SerializeObject(
                new
                {
                    email = "eve.holt@reqres.in",
                    password = "pistol"
                });
            var res11 = await userClient.MakeResponse<RegisterResponse>(HttpMethod.Post, "register", obj11);

            var obj12 = JsonConvert.SerializeObject(
                new
                {
                    email = "eve.holt@reqres.in",
                });
            var res12 = await userClient.MakeResponse<RegisterResponse>(HttpMethod.Post, "register", obj12);

            var obj13 = JsonConvert.SerializeObject(
                new
                {
                    email = "eve.holt@reqres.in",
                    password = "cityslicka"
                });
            var res13 = await userClient.MakeResponse<LoginResponse>(HttpMethod.Post, "login", obj13);

            var obj14 = JsonConvert.SerializeObject(
                new
                {
                    email = "eve.holt@reqres.in",
                });
            var res14 = await userClient.MakeResponse<LoginResponse>(HttpMethod.Post, "login", obj14);

            var res15 = await userClient.MakeResponse<ListResponse<User>>(HttpMethod.Get, "users?delay=3");
        }
    }
}
