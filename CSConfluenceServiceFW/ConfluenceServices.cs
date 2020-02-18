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

        public AddNewPageCompositeResponse AddNewPageComposite(AddNewPageCompositeRequest request)
        {
            AddNewPageCompositeResponse response = new AddNewPageCompositeResponse();

            try
            {
                IsPageExistsResponse isPageExistsResponse =
                    IsPageExists(new IsPageExistsRequest() { 
                        PageTitle = request.PageTitle
                        , Password = request.Password
                        , Username = request.Username
                        , URL = request.URL
                        , SpaceKey = request.SpaceKey
                    });

                if(isPageExistsResponse.Result.Success())
                {
                    DeletePageResponse deletePageResponse =
                        DeletePage(new DeletePageRequest()
                        {
                            PageTitle = request.PageTitle
                            , Password = request.Password
                            , Username = request.Username
                            , URL = request.URL
                            , SpaceKey = request.SpaceKey
                        });
                }

                AddNewPageResponse addNewPageResponse =
                    AddNewPage(new AddNewPageRequest()
                    {
                        Password = request.Password
                        , Username = request.Username
                        , URL = request.URL
                        , SpaceKey = request.SpaceKey
                        , ParentPageTitle = request.ParentPageTitle
                        , PageTitle = request.PageTitle
                    });
                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };

                response.AddNewPageResult = addNewPageResponse.AddNewPageResult;
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }//AddNewPageComposite

        public async Task<UploadAttachmentCompositeRespone> UploadAttachmentComposite(UploadAttachmentCompositeRequest request)
        {
            UploadAttachmentCompositeRespone response = new UploadAttachmentCompositeRespone();

            try
            {
                UploadAttachmentResponse uploadAttachmentResponse = null;

                IsPageExistsResponse isPageExistsResponse =
                    IsPageExists(new IsPageExistsRequest()
                    {
                        PageTitle = request.PageTitle
                        ,
                        Password = request.Password
                        ,
                        Username = request.Username
                        ,
                        URL = request.URL
                        ,
                        SpaceKey = request.SpaceKey
                    });

                if (isPageExistsResponse.Result.Success())
                {
                    uploadAttachmentResponse = await
                        UploadAttachment(new UploadAttachmentRequest()
                        {
                            PageTitle = request.PageTitle
                            ,
                            Password = request.Password
                            ,
                            Username = request.Username
                            ,
                            URL = request.URL
                            ,
                            SpaceKey = request.SpaceKey
                            , ImageFileBase64String = request.ImageFileBase64String
                            , FileName = request.FileName
                        });
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
                }


                response.UploadAttachmentResult = uploadAttachmentResponse.UploadAttachmentResult;
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }//UploadAttachmentComposite

    }
}
