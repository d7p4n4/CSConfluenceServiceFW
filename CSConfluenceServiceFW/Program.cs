using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSConfluenceServiceFW
{
    class Program
    {
        public static void Main(String[] args)
        {/*
            UpdateOrAddPageCompositeResponse updateOrAddPageCompositeResponse =
                new ConfluenceServices().UpdateOrAddPageComposite(new UpdateOrAddPageCompositeRequest()
                {
                    URL = "http://10.82.220.43:8090/rest/api/content"
                    ,
                    Username = "fejl_artan"
                    ,
                    Password = "Ar2019"
                    ,
                    PageTitle = "frmTor_Partner_o.picPartner.fraLevelezesi @ KepernyoAdatkor"
                    ,
                    FileName = "Image.jpg"
                    ,
                    SpaceKey = "NOV"
                    ,
                    ImageFileBase64String = "<html>\r\n <body>\r\n <p>frmTor_Partner_o.picPartner.fraLevelezesi</p>\r\n <p>\r\n </p>\r\n <p>\r\n Konténer: </p>\r\n <p>Képernyo elem lista</p>\r\n <table border=\"1\">\r\n <tr>\r\n <td>Kód</td>\r\n <td>Leírás</td>\r\n <td>Adattipus</td>\r\n <td>Adatforrás</td>\r\n </tr>\r\n <tr>\r\n <td><a href=\"/display/NOV/frmTor_Partner_o.picPartner.fraLevelezesi.txtLevelezesPf @ kepernyo elem\">txtLevelezesPf</a></td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n </tr>\r\n <tr>\r\n <td><a href=\"/display/NOV/frmTor_Partner_o.picPartner.fraLevelezesi.cmbLevelezesMegye @ kepernyo elem\">cmbLevelezesMegye</a></td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n </tr>\r\n <tr>\r\n <td><a href=\"/display/NOV/frmTor_Partner_o.picPartner.fraLevelezesi.txtLevelezesNev @ kepernyo elem\">txtLevelezesNev</a></td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n </tr>\r\n <tr>\r\n <td><a href=\"/display/NOV/frmTor_Partner_o.picPartner.fraLevelezesi.txtLevelezesUtca @ kepernyo elem\">txtLevelezesUtca</a></td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n </tr>\r\n <tr>\r\n <td><a href=\"/display/NOV/frmTor_Partner_o.picPartner.fraLevelezesi.txtLevelezesVaros @ kepernyo elem\">txtLevelezesVaros</a></td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n </tr>\r\n <tr>\r\n <td><a href=\"/display/NOV/frmTor_Partner_o.picPartner.fraLevelezesi.txtLevelezesIrsz @ kepernyo elem\">txtLevelezesIrsz</a></td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n </tr>\r\n <tr>\r\n <td><a href=\"/display/NOV/frmTor_Partner_o.picPartner.fraLevelezesi.cmbLevelezesOrszag @ kepernyo elem\">cmbLevelezesOrszag</a></td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n </tr>\r\n <tr>\r\n <td><a href=\"/display/NOV/frmTor_Partner_o.picPartner.fraLevelezesi.lblSuspect2 @ kepernyo elem\">lblSuspect2</a></td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n </tr>\r\n <tr>\r\n <td><a href=\"/display/NOV/frmTor_Partner_o.picPartner.fraLevelezesi.lblLevelezesPf @ kepernyo elem\">lblLevelezesPf</a></td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n </tr>\r\n <tr>\r\n <td><a href=\"/display/NOV/frmTor_Partner_o.picPartner.fraLevelezesi.lblLevelezesMegye @ kepernyo elem\">lblLevelezesMegye</a></td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n </tr>\r\n <tr>\r\n <td><a href=\"/display/NOV/frmTor_Partner_o.picPartner.fraLevelezesi.lblLevelezesNev @ kepernyo elem\">lblLevelezesNev</a></td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n </tr>\r\n <tr>\r\n <td><a href=\"/display/NOV/frmTor_Partner_o.picPartner.fraLevelezesi.lblLevelezesUtca @ kepernyo elem\">lblLevelezesUtca</a></td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n </tr>\r\n <tr>\r\n <td><a href=\"/display/NOV/frmTor_Partner_o.picPartner.fraLevelezesi.lblLevelezesVaros @ kepernyo elem\">lblLevelezesVaros</a></td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n </tr>\r\n <tr>\r\n <td><a href=\"/display/NOV/frmTor_Partner_o.picPartner.fraLevelezesi.lblLevelezesOrszag @ kepernyo elem\">lblLevelezesOrszag</a></td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n <td>\r\n </td>\r\n </tr>\r\n </table>\r\n </body>\r\n</html>"
                });*/

            UploadAttachmentCompositeResponse uploadAttachmentCompositeResponse =
                new ConfluenceServices().UploadAttachmentComposite(new UploadAttachmentCompositeRequest()
                {
                    URL = "http://10.82.220.43:8090/rest/api/content"
                    ,
                    Username = "fejl_artan"
                    ,
                    Password = "Ar2019"
                    ,
                    PageTitle = "Képtár"
                    ,
                    FileName = "like.2.jpg"
                    ,
                    SpaceKey = "NOV"
                    ,
                    ImageFileBase64String = "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"

                });
        }
    }
}
