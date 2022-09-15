
using PYP_Day16_Task.Entities;
using PYP_Day16_Task.Repositories.Abstract;
using PYP_Day16_Task.Repositories.Concrete;
using PYP_Day16_Task.Services.Abstract;
using PYP_Day16_Task.Services.Concrete;

//Repositories
IVCardRepository repository = new EFVCardRepository();

//Services
IVCardService vCardService = new VCardService(repository);
ClientService clientService=new ClientService();
IQrService qrService = new QrService();

//Url
string url = "https://randomuser.me/api?results=50";

List<VCard> cards =await clientService.GetAllAsyncFromUrl(url);
foreach (var card in cards)
{
   await vCardService.AddAsync(card);
   Console.WriteLine(qrService.GetVCardText(card));
    Console.WriteLine(new string('-',50));
}

//{
//    "results":
//    [
//    {
//        "gender":"female",
//        "name":
//        {
//            "title":"Miss",
//            "first":"Ana",
//            "last":"Kovač"
//        },
//        "location":
//        {
//            "street":
//            {
//                "number":6834,
//                "name":"Miodraga Popovića"
//            },
//            "city":"Kosovo Polje",
//            "state":"Kosovo",
//            "country":"Serbia",
//            "postcode":35298,
//            "coordinates":
//            {
//                "latitude":"62.9522",
//                "longitude":"93.4861"
//            },
//            "timezone":
//            {
//                "offset":"+9:30",
//                "description":"Adelaide, Darwin"
//            }

//        },
//        "email":"ana.kovac@example.com",
//        "login":
//        {
//            "uuid":"053ea853-4fca-44b5-bfe8-f6cd9494bd16",
//            "username":"orangewolf485",
//            "password":"umbrella",
//            "salt":"9VNrTun7",
//            "md5":"5aed991a0ac45fa5560fa4628b779c61",
//            "sha1":"9374c507dc8159209a79f364e7a4a56962dd237c",
//            "sha256":"5a2507c71ae86b2083dcf6480a83e67a43b25057db09f0fa0975966ae173e18a"
//        },
//        "dob":
//        {
//            "date":"1987-11-03T03:02:44.992Z",
//            "age":34
//        },
//        "registered":
//        {
//            "date":"2019-10-11T07:50:28.786Z",
//            "age":2
//        },
//        "phone":"015-2781-358",
//        "cell":"064-1172-567",
//        "id":
//        {
//            "name":"SID",
//            "value":"956265331"
//        },
//        "picture":
//        {
//            "large":"https://randomuser.me/api/portraits/women/59.jpg",
//            "medium":"https://randomuser.me/api/portraits/med/women/59.jpg",
//            "thumbnail":"https://randomuser.me/api/portraits/thumb/women/59.jpg"
//        },
//        "nat":"RS"
//    }
//    ]
//}