using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
namespace AutoHubWITHSQL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAUTOHUBWITHSQL" in both code and config file together.
    [ServiceContract]
    public interface IAUTOHUBWITHSQL
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "Login?sEmail={sEmail}&sPassword={sPassword}&idusertype={idusertype}")]
        Responce Login(string sEmail, string sPassword,int idusertype);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ResetPwd?sEmail={sEmail}&sPassword={sPassword}&sOldPwd={sOldPwd}&idusertype={idusertype}")]
        Responce ResetPwd(string sEmail, string sPassword, string sOldPwd, int idusertype);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "AlterCustomerDocument?data={data}")]
        CustomerDocs AlterCustomerDocument(string data);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GETCustomerDocument?Userid={iUserid}")]
        CustomerDocs GETCustomerDocument(int iUserid);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ALterTwoWheelerJobCart?sJobKart={sJobKart}")]
        Responce ALterTwoWheelerJobCart(string sJobKart);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ALterFourWheelerJobCart?sJobKart={sJobKart}")]
        Responce ALterFourWheelerJobCart(string sJobKart);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GETJobCart?sJobKart={sJobKart}")]
        Responce GETJobCart(string sJobKart);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ALterTwoWheelerAcceptance?sJobKart={sJobKart}")]
        Responce ALterTwoWheelerAcceptance(string sJobKart);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GETJobCartCartAcceptance?sJobKart={sJobKart}")]
        Responce GETJobCartCartAcceptance(string sJobKart);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ALterSentJobCart?sJobKart={sJobKart}")]
        Responce ALterSentJobCart(string sJobKart);
        //User Update
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GETUser?UserData={sData}")]
        Responce GETUser(string sData);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "AlterUser?UserData={sData}")]
        Responce AlterUser(string sData);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ALterFourWheelerAcceptance?sJobKart={sJobKart}")]
        Responce ALterFourWheelerAcceptance(string sJobKart);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GETFourJobCartAcceptance?sJobKart={sJobKart}")]
        Responce GETFourJobCartAcceptance(string sJobKart);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "SENDEMAIL?Semail={Semail}")]
        Responce SENDEMAIL(string Semail);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "sendOTP?data={sData}")]
        Responce sendOTP(string sData);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ALterGarageRating?sRating={sRating}")]
        Responce ALterGarageRating(string sRating);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GETGarageRating?sRating={sRating}")]
        Responce GETGarageRating(string sRating);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ALterFavourite?sfavourite={sfavourite}")]
        Responce ALterFavourite(string sfavourite);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GETFavouriteGarge?sfavourite={sfavourite}")]
        Responce GETFavouriteGarge(string sfavourite);
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GETFavouriteGarges?sfavourite={sfavourite}")]
        Responce GETFavouriteGarges(string sfavourite);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GETGargeLocation?sfavourite={sfavourite}")]
        Responce GETGargeLocation(string sfavourite);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetDetailsFourwheelerData?sJobcart={sJobcart}")]
        Responce GetDetailsFourwheelerData(string sJobcart);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetDetailsTwowheelerData?sJobcart={sJobcart}")]
        Responce GetDetailsTwowheelerData(string sJobcart);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetOrder?OrderData={OrderData}")]
        Responces GetOrder(string OrderData);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "CreateOrder?OrderData={OrderData}")]
        Responces CreateOrder(string OrderData);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetJobCartDetails?soDetails={soDetails}")]
        Responces GetJobCartDetails(string soDetails);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetForeJobCartDetails?soDetails={soDetails}")]
        Responces GetForeJobCartDetails(string soDetails);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetTwoJobCartDetails?soDetails={soDetails}")]
        Responces GetTwoJobCartDetails(string soDetails); 

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ALterGaragePickupandDrop?sPickupandDrops={sPickupandDrops}")]
        Responce ALterGaragePickupandDrop(string sPickupandDrops);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetGaragePickupandDrop?sPickupandDrops={sPickupandDrops}")]
        Responce GetGaragePickupandDrop(string sPickupandDrops);

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ALterGarageTime?sTImeSlovet={sTImeSlovet}")]
        Responce ALterGarageTime(string sTImeSlovet);
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetGarageTime?sTImeSlovet={sTImeSlovet}")]
        Responce GetGarageTime(string sTImeSlovet);
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetGarageTimeMaster")]
        Responce GetGarageTimeMaster();

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetDetailsData?sJobcart={sJobcart}")]
        Responce GetDetailsData(string sJobcart);

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "CancelOrder?iOrderid={iOrderid}")]
        Responces CancelOrder(int iOrderid);
    }
}
