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
                        , request.ParentPageId
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
                        , request.URL
                        , request.PageId
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
                        , request.PageId
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


        public IsPageExistsCompositeResponse IsPageExistsComposite(IsPageExistsCompositeRequest request)
        {
            IsPageExistsCompositeResponse response = new IsPageExistsCompositeResponse();

            try
            {
                GetIdByTitleResponse getIdByTitleResponse =
                    GetIdByTitle(new GetIdByTitleRequest()
                    {
                        Password = request.Password
                        , PageTitle = request.PageTitle
                        , Username = request.Username
                        , URL = request.URL
                        , SpaceKey = request.SpaceKey
                    });

                response.GetIdByTitleResult = getIdByTitleResponse.GetIdByTitleResult;

                if (getIdByTitleResponse.Result.Success() && getIdByTitleResponse.GetIdByTitleResult.SuccessResponse.Results.Count > 0)
                {
                    IsPageExistsResponse isPageExistsResponse =
                        IsPageExists(new IsPageExistsRequest()
                        {
                            Password = request.Password
                            ,
                            Username = request.Username
                            ,
                            URL = request.URL
                            ,
                            SpaceKey = request.SpaceKey
                            ,
                            PageId = getIdByTitleResponse.GetIdByTitleResult.SuccessResponse.Results[0].Id.ToString()
                        });

                    response.isPageExistsResult = isPageExistsResponse.IsPageExistsResult;
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
                }
                else
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = "Nincs ilyen nevű oldal!" };
                }
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }//IsPageExistsComposite

        public UpdatePageResponse UpdatePage(UpdatePageRequest request)
        {
            UpdatePageResponse response = new UpdatePageResponse();

            try
            {
                response.UpdatePageResult =
                    new ConfluenceAPIMetodusok().UpdateConfluencePage(
                        request.Password
                        , request.Username
                        , request.URL
                        , request.PageId
                        , request.Content
                        , request.VersionNumber
                        , request.PageTitle
                        );
                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }//DeletePage

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
                        , request.PageId
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

        public DeletePageCompositeResponse DeletePageComposite(DeletePageCompositeRequest request)
        {
            DeletePageCompositeResponse response = new DeletePageCompositeResponse();

            try
            {
                IsPageExistsCompositeResponse isPageExistsCompositeResponse =
                    IsPageExistsComposite(new IsPageExistsCompositeRequest()
                    {
                        PageTitle = request.PageTitle
                        , Password = request.Password
                        , Username = request.Username
                        , URL = request.URL
                        , SpaceKey = request.SpaceKey
                    });

                if (isPageExistsCompositeResponse.Result.Success())
                {
                    DeletePageResponse deletePageResponse =
                        DeletePage(new DeletePageRequest()
                        {
                            PageId = isPageExistsCompositeResponse.GetIdByTitleResult.SuccessResponse.Results[0].Id.ToString()
                            ,
                            Password = request.Password
                            ,
                            Username = request.Username
                            ,
                            URL = request.URL
                            ,
                            SpaceKey = request.SpaceKey
                        });

                    response.DeletePageResult = deletePageResponse.DeletePageResult;
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };

                }
                else
                {
                    response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = "Nem létezik ilyen névvel oldal!" });
                }
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }//DeletePageComposite

        public AddNewPageCompositeResponse AddNewPageComposite(AddNewPageCompositeRequest request)
        {
            AddNewPageCompositeResponse response = new AddNewPageCompositeResponse();

            try
            {
                DeletePageCompositeResponse deletePageCompositeResponse =
                    DeletePageComposite(new DeletePageCompositeRequest()
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

                IsPageExistsCompositeResponse isPageExistsCompositeResponseParentPage =
                    IsPageExistsComposite(new IsPageExistsCompositeRequest()
                    {
                        PageTitle = request.ParentPageTitle
                        ,
                        Password = request.Password
                        ,
                        Username = request.Username
                        ,
                        URL = request.URL
                        ,
                        SpaceKey = request.SpaceKey
                    });

                if (isPageExistsCompositeResponseParentPage.Result.Success())
                {
                    AddNewPageResponse addNewPageResponse =
                        AddNewPage(new AddNewPageRequest()
                        {
                            Password = request.Password
                            ,
                            Username = request.Username
                            ,
                            URL = request.URL
                            ,
                            SpaceKey = request.SpaceKey
                            ,
                            ParentPageId = isPageExistsCompositeResponseParentPage.GetIdByTitleResult.SuccessResponse.Results[0].Id.ToString()
                            ,
                            PageTitle = request.PageTitle
                            , Content = request.Content
                        });
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };

                    response.AddNewPageResult = addNewPageResponse.AddNewPageResult;
                }
                else
                {
                    response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = "Nincs oldal a szülőoldal névvel!" });
                }
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

                IsPageExistsCompositeResponse isPageExistsCompositeResponse =
                    IsPageExistsComposite(new IsPageExistsCompositeRequest()
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

                if (isPageExistsCompositeResponse.Result.Success())
                {
                    uploadAttachmentResponse = await
                        UploadAttachment(new UploadAttachmentRequest()
                        {
                            PageId = isPageExistsCompositeResponse.GetIdByTitleResult.SuccessResponse.Results[0].Id.ToString()
                            ,
                            Password = request.Password
                            ,
                            Username = request.Username
                            ,
                            URL = request.URL
                            
                            , ImageFileBase64String = request.ImageFileBase64String
                            , FileName = request.FileName
                        });
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
                    response.UploadAttachmentResult = uploadAttachmentResponse.UploadAttachmentResult;
                }
                else
                {
                    response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = "Nincs oldal a megadott címmel!"});
                }

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }//UploadAttachmentComposite

    }
}
