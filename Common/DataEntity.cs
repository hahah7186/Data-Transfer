using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickstarts.DataAccessClient.Common
{
    class DataEntity
    {

        //一.設備開機報告
        //1.設備程式開啟後進行報站, 當第一片產品進行上料確認時需要對系統進行報站動作,系統會回復一組含
        //token 的字符串，後續設備在進行其它報告請求(上料確認、數據上傳、過站報告)，系統資料交換時均需要報告
        //這組字符串, 如果報告的內容與字符串中任意一個不匹配，系統將會拒絕與設備進行資料交換，即設備報站失
        // 敗。CG Quality Traceability System 8
        //2. 字符串中 token 的使用期限為四個小時， expiry_date 為 Token 的失效時間， 失效后設備需要重新向系
        //統進行報站取得新的 Token。
        //3.設備報站主要訊息為 IP、工站、設備 ID，使用者可在報站前對 IP、工站、設備 ID 進行修改，進行報站後
        //IP、工站、設備 ID 將鎖定，不可進行修改動作。
        //4.報站時系統會回復該工站設備相關訊息，系統回復的訊息在設備端只能顯示，不可進行修改
        //备注：
        //1.設備報站前，需請制工將設備信息進行註冊登記，否則設備無法正常加工檢測產品
        //2.報站返回服務器當前時間 sysdate，設備需增加校時功能

        //GL:http://sfc02-icge-gl.ipebg.efoxconn.com:8080/sfc_cg_api/enterEqu
        //LH:http://sfc02-icge-lh.ipebg.efoxconn.com:8080/sfc_cg_api/enterEqu
        //ZZK:http://sfc02-icge-zzk.ipebg.efoxconn.com:8080/sfc_cg_api/enterEqu
        //ZZC:http://sfc02-icge-zzc.ipebg.efoxconn.com:8080/sfc_cg_api/enterEqu

        public struct Data_Starting_Up
        {
            //填入設備編號
            public string machine_id;
            //填入工站
            public string station_id;
            //填入設備IP
            public string ip;
        }
        //一.設備開機報告——反馈信息
        //成功:
        /*{"rc":"000",
        "rm":"報站成功",
        "station_id": "DAAZZKB013FL0508",
        "wrkst_name": "FrameDispense",
        "station_type": "DISPENSE",
        "ip": "10.176.80.68",
        "product": "801",
        "part": "CG",
        "building": "HZGL",
        "floor_no": "ZZ-B01-3F",
        "line_name": "ZZKB013F-L001",
        "host_id": "DAAZZKB013FL0508",
        "module_id":"DAAZZKB013FL0508",
        "tb_control_flag":"Y",
        "sysdate":"20190124183658",
        "token":"f9e84c950fd7980988a63480e4fe3cdfe6eb21b397046a65a1ee2ca11b7f26a9188f716369877c014b93cf4fd85b3859",
        "change_date": "2018-10-12 18:00:00",
        "interval_time": "240",
        "version": "1.0"
        }*/
        //失败：
        /*{"rc":"400",
            "rm":"設備報站信息失效，請重新報站",
            "sysdate":"20190124183658"
            }
         */
        public struct Res_Data_Starting_Up
        {
            //調用接口返回代碼（ 000 成功、非 000失敗）
            public string rc;
            //調用接口返回提示信息
            public string rm;
            //返回設備編號
            public string station_id;
            //返回工站名稱
            public string wrkst_name;
            //返回工站類型
            public string station_type;
            //返回設備 IP
            public string ip;
            //返回生產機種
            public string product;
            //返回零件類型
            public string part;
            //返回生產廠區
            public string building;
            //返回設備所在樓層
            public string floor_no;
            //返回設備所在線別
            public string line_name;
            //返回中控機台編號
            public string host_id;
            //返回電控模組編號
            public string module_id;
            //返回當前所報工站 Traceability 是否管控的結果
            public string tb_control_flag;
            //服務器當前時間
            public string sysdate;
            //返回訪問令牌
            public string token;
            //返回 token 生效時間點
            public string change_date;
            //返回 token 生存時長
            public string internal_time;
            //返回專案版本
            public string version;
            //token過期時間
            public string expiry_date;
        }


//5.11.Display Clean Glue
        public struct Productinfo {
            //填入掃描產品主條碼
            public string barcode;
            //填入條碼類型:CG/DISPLAY
            public string code_type;
            //填入固定製程類型： Assembly
            public string process_type;
            //填入工站名稱： 機台報站返回的
            //wrkst_name
            public string station_id;
        }

        public struct Machineinfo {
            //填入設備 IP
            public string host_ip;
            //填入設備機台編號： 設備報站返回的
            //station_id
            public string machine_id;
            //填入中控管制編號：設備報站返回
            //host_id
            public string control_machine_id;
            //填入模組編號：設備報站返回
            //module_id       
            public string module_id;
            //填入固定機台類型： GLUE_CLEAN
            public string equipment_type;
            //填入機台所在位置： 設備報站返回
            //floor_no
            public string location;
            //填入產線編號： 設備報站返回
            //line_name
            public string line;
        }

        public struct Parainfo {
            //填入清溢膠參數名稱
            public string item_name;
            //填入清溢膠參數名稱對應的值
            public string item_val;
        }

        public struct Recipeinfo {
            //填入檢測開始時間：
            //yyyymmddhhmmss(24H)
            //1.時間格式校驗;
            //2.start_time<end_time 校驗;
            //3.時間校時:機台時間與服務器時間差
            //異 5 分鐘之內通過;否則均給予異常提
            //示
            public string start_time;
            //填入檢測結束時間：
            //yyyymmddhhmmss(24H)
            //1.時間格式校驗;
            //2.時間校時:機台時間與服務器時間差
            //異 5 分鐘之內通過;否則均給予異常提
            //示
            public string end_time;
            //填入產品加工使用治具碼
            public string fixture_id;
            //填入產品加工使用穴號
            public string cavity;
            //清溢膠設備信息集合
            public Parainfo[] parainfo;
        }

        public struct Display_Clean_Glue {
            //填入訪問令牌：設備報站返回 token
            public string token;
            //host_ip+時間
            //（ yyyymmddhhmmssfff，時間精確
            //至毫秒） +6 碼流水號， host_ip 需刪
            //除"."，流水碼 000001~999999 循環
            //使用
            public string request_id;
            //產品集合
            public Productinfo productinfo;
            //設備集合
            public Machineinfo machineinfo;
            //採集信息集合
            public Recipeinfo recipeinfo;
        }

        public struct Res_Display_Clean_Glue {
            //返回機台調用接口請求序列號
            public string request_id;
            //返回調用接口代碼（ 000 成功、非 000失敗）
            public string rm;
            //返回調用接口提示信息
            public string rc;
            //返回服務器當前時間
            public string sysdate;
        }
    }
}
