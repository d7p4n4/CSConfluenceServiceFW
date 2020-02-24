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

        public UploadAttachmentResponse UploadAttachment(UploadAttachmentRequest request)
        {
            UploadAttachmentResponse response = new UploadAttachmentResponse();

            try
            {
                response.UploadAttachmentResult =
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

                if (response.GetIdByTitleResult.FailedResponse == null && response.GetIdByTitleResult.SuccessResponse.Results.Count > 0)
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
                }
                else
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = "Nincs ilyen nevű oldal! Nincs ID!" };
                }
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

                if (response.IsPageExistsResult.FailedResponse == null)
                {
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
                
                if (getIdByTitleResponse.Result.Success())
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
                    if (isPageExistsResponse.IsPageExistsResult.FailedResponse == null)
                    {
                        response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
                    }
                    else
                    {
                        response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = "Nincs ilyen nevű oldal!" };
                    }
                }
                else
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = "Nincs ilyen nevű oldal! Nincs ID!" };
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
                        request.PageTitle
                        , request.PageId
                        , request.Content
                        , request.URL
                        , request.Username
                        , request.Password
                        , request.VersionNumber
                        );

                if (response.UpdatePageResult.FailedResponse == null)
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
                }
                else
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = "Nem sikerült a frissítés!" };
                }
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }//UpdatePage

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

                if (response.DeletePageResult.FailedResponse == null)
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
                }
                else
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = "Nem sikerült a törlés!" };
                }
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
                            PageId = isPageExistsCompositeResponse.isPageExistsResult.SuccessResponse.Id.ToString()
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

                    if (response.DeletePageResult.FailedResponse == null)
                    {
                        response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
                    }
                    else
                    {
                        response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = "Nem sikerült a törlés!" };
                    }

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
                            ParentPageId = isPageExistsCompositeResponseParentPage.isPageExistsResult.SuccessResponse.Id.ToString()
                            ,
                            PageTitle = request.PageTitle
                            , Content = request.Content
                        });
                    
                    response.AddNewPageResult = addNewPageResponse.AddNewPageResult;

                    if (response.AddNewPageResult.FailedResponse == null)
                    {
                        response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
                    }
                    else
                    {
                        response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = "Nem sikerült az oldalt létrehozni!" };
                    }
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

        public UploadAttachmentCompositeResponse UploadAttachmentComposite(UploadAttachmentCompositeRequest request)
        {
            UploadAttachmentCompositeResponse response = new UploadAttachmentCompositeResponse();

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
                    uploadAttachmentResponse =
                        UploadAttachment(new UploadAttachmentRequest()
                        {
                            PageId = isPageExistsCompositeResponse.isPageExistsResult.SuccessResponse.Id.ToString()
                            ,
                            Password = request.Password
                            ,
                            Username = request.Username
                            ,
                            URL = request.URL

                            ,
                            ImageFileBase64String = request.ImageFileBase64String
                            ,
                            FileName = request.FileName
                        });
                    response.UploadAttachmentResult = uploadAttachmentResponse.UploadAttachmentResult;

                    if (response.UploadAttachmentResult.FailedResponse == null)
                    {
                        response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
                    }
                    else
                    {
                        response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = "Nem sikerült feltölteni a képet!" };
                    }
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

        public UpdateOrAddPageCompositeResponse UpdateOrAddPageComposite(UpdateOrAddPageCompositeRequest request)
        {
            UpdateOrAddPageCompositeResponse response = new UpdateOrAddPageCompositeResponse();

            try
            {
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
                    UpdatePageResponse updatePageResponse =
                        UpdatePage(new UpdatePageRequest()
                        {
                            PageId = isPageExistsCompositeResponse.isPageExistsResult.SuccessResponse.Id.ToString()
                            ,
                            PageTitle = request.PageTitle
                            ,
                            Password = request.Password
                            ,
                            Username = request.Username
                            ,
                            URL = request.URL
                            ,
                            VersionNumber = (isPageExistsCompositeResponse.isPageExistsResult.SuccessResponse.Version.Number + 1).ToString()
                            , Content = request.Content
                        });

                    response.UpdatePageResult = updatePageResponse.UpdatePageResult;

                    if (response.UpdatePageResult.FailedResponse == null)
                    {
                        response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
                    }
                    else
                    {
                        response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = "Nem sikerült frissíteni az oldalt!" };
                    }

                }
                else
                {

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
                                ParentPageId = isPageExistsCompositeResponseParentPage.isPageExistsResult.SuccessResponse.Id.ToString()
                                ,
                                PageTitle = request.PageTitle
                                ,
                                Content = request.Content
                            });
                        response.AddNewPageResult = addNewPageResponse.AddNewPageResult;

                        if (response.AddNewPageResult.FailedResponse == null)
                        {
                            response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
                        }
                        else
                        {
                            response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = "Nem sikerült az új oldalt létrehozni!" };
                        }
                    }
                    else
                    {
                        response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = "Nincs oldal a szülőoldal névvel!" });
                    }
                }
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }//AddNewPageComposite

    }
}
