using CSConfluenceCapFW;
using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSConfluenceServiceFW
{
    public class ConfluenceServices
    {
        public AddNewPageResponse AddNewPage(AddNewPageRequest request)
        {
            AddNewPageResponse response = new AddNewPageResponse();

            try
            {
                response.AddNewPageResult =
                    new ConfluenceAPIMetodusok().AddConfluencePage(
                        request.PageTitle
                        , request.SpaceKey
                        , request.ParentPageTitle
                        , request.Content
                        , request.URL
                        , request.Username
                        , request.Password
                        );
                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }//AddNewPage

        public async Task<UploadAttachmentResponse> UploadAttachment(UploadAttachmentRequest request)
        {
            UploadAttachmentResponse response = new UploadAttachmentResponse();

            try
            {
                response.UploadAttachmentResult = await
                    new ConfluenceAPIMetodusok().UploadAttachment(
                        request.Username
                        , request.Password
                        , request.SpaceKey
                        , request.URL
                        , request.PageTitle
                        , request.ImageFileBase64String
                        , request.FileName
                        );
                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }//UploadAttachment

        public GetIdByTitleResponse GetIdByTitle(GetIdByTitleRequest request)
        {
            GetIdByTitleResponse response = new GetIdByTitleResponse();

            try
            {
                response.GetIdByTitleResult = 
                    new ConfluenceAPIMetodusok().GetIdByTitle(
                        request.Username
                        , request.Password
                        , request.SpaceKey
                        , request.URL
                        , request.PageTitle
                        );
                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;

        }//GetIdByTitle

        public IsPageExistsResponse IsPageExists(IsPageExistsRequest request)
        {
            IsPageExistsResponse response = new IsPageExistsResponse();

            try
            {
                response.IsPageExistsResult =
                    new ConfluenceAPIMetodusok().IsPageExists(
                        request.URL
                        , request.PageTitle
                        , request.SpaceKey
                        , request.Username
                        , request.Password
                        );
                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }//IsPageExists

        public DeletePageResponse DeletePage(DeletePageRequest request)
        {
            DeletePageResponse response = new DeletePageResponse();

            try
            {
                response.DeletePageResult =
                    new ConfluenceAPIMetodusok().DeletePage(
                        request.Password
                        , request.Username
                        , request.URL
                        , request.PageTitle
                        , request.SpaceKey
                        );
                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }//DeletePage

        public AddNewPageKompozitResponse AddNewPageKompozit(AddNewPageKompozitRequest request)
        {
            AddNewPageKompozitResponse response = new AddNewPageKompozitResponse();

            try
            {
                response.IsPageExistsResult =
                    new ConfluenceAPIMetodusok().IsPageExists(
                        request.URL
                        , request.PageTitle
                        , request.SpaceKey
                        , request.Username
                        , request.Password
                        );

                if(response.IsPageExistsResult.FailedResponse == null)
                {
                    response.DeletePageResult =
                        new ConfluenceAPIMetodusok().DeletePage(
                            request.Password
                            , request.Username
                            , request.URL
                            , request.PageTitle
                            , request.SpaceKey
                            );
                }

                response.AddNewPageResult =
                    new ConfluenceAPIMetodusok().AddConfluencePage(
                        request.PageTitle
                        , request.SpaceKey
                        , request.ParentPageTitle
                        , request.Content
                        , request.URL
                        , request.Username
                        , request.Password
                        ); 
                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }//AddNewPageKompozit


    }
}
