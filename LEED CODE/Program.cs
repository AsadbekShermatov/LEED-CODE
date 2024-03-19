//int target =14;

//List<int> num = new List<int>() { 2, 7, 11, 15 };

//for(int i = 0; i < num.Count; i++)
//{
//    for (int j = 0; j < num.Count; j++)
//    {
//        if (num[i] + num[j] == target)
//        {
//            Console.WriteLine(num[i]);
//            Console.WriteLine(num[j]);

//        }

//    }

//}


//int num=121, sum=0, temp, r;

//temp = num;
//while(num > 0)
//{
//    r = num % 10;
//    sum = (sum * 10) + r;
//    num /= 10;
//    if(temp == sum)
//    {
//        Console.WriteLine(true);
//    }
//}


using System.Text.Json;
using LEED_CODE.ApiResponse;
using LEED_CODE.Data;
using LEED_CODE.Models;

string api = "https://jsonmock.hackerrank.com/api/article_users ";

JsonNamePolicy policy = new JsonNamePolicy();
List<UserDb> userDbs = new List<UserDb>();
AppDBContext dBContext = new AppDBContext();

using (var client = new HttpClient())
{
    var request = await client.GetAsync(api);
    var reString = await request.Content.ReadAsStringAsync();
    var responseModel = JsonSerializer.Deserialize<ResponseModel>(reString, new JsonSerializerOptions { PropertyNamingPolicy = policy});
    for(int i =0; i <= responseModel.total_pages; i++)
    {
        var request2 = await client.GetAsync($"https://jsonmock.hackerrank.com/api/article_users?pages={i}");
        var reString2 = await request2.Content.ReadAsStringAsync();
        var responseModel2 = JsonSerializer.Deserialize<ResponseModel>(reString2, new JsonSerializerOptions { PropertyNamingPolicy = policy });
        foreach(var item in responseModel2.data)
        {
            userDbs.Add(new UserDb
            {
                UserName = item.username,
                About = item.about,
                SubmissionCount = item.submission_count,
                CommentCount = item.comment_count,
                Submitted = item.submitted,
                CreatedAt = item.created_at,
                UpdatedAt = item.updated_at,
            }) ;
        }
    }
}
dBContext.UserDbs.AddRange(userDbs);
dBContext.SaveChanges();
