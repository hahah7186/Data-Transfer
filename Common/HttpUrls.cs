using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickstarts.DataAccessClient.Common
{
    public static class HttpUrls
    {
        public const string GL_URL_STARTING_UP = "http://sfc02-icge-gl.ipebg.efoxconn.com:8080/sfc_cg_api/enterEqu";
        public const string LH_URL_STARTING_UP = "http://sfc02-icge-lh.ipebg.efoxconn.com:8080/sfc_cg_api/enterEqu";
        public const string ZZK_URL_STARTING_UP = "http://sfc02-icge-zzk.ipebg.efoxconn.com:8080/sfc_cg_api/enterEqu";
        public const string ZZC_URL_STARTING_UP = "http://sfc02-icge-zzc.ipebg.efoxconn.com:8080/sfc_cg_api/enterEqu";

        public const string GL_URL_LOAD_MATERIAL_CONFIRMATION = "http://sfc02-icge-gl.ipebg.efoxconn.com:8080/sfc_cg_api/mpline/sfc/do_check";
        public const string LH_URL_LOAD_MATERIAL_CONFIRMATION = "http://sfc02-icge-lh.ipebg.efoxconn.com:8080/sfc_cg_api/mpline/sfc/do_check";
        public const string ZZK_URL_LOAD_MATERIAL_CONFIRMATION = "http://sfc02-icge-zzk.ipebg.efoxconn.com:8080/sfc_cg_api/mpline/sfc/do_check";
        public const string ZZC_URL_LOAD_MATERIAL_CONFIRMATION = "http://sfc02-icge-zzc.ipebg.efoxconn.com:8080/sfc_cg_api/mpline/sfc/do_check";

        public const string GL_URL_PASS_STATION_REPORT = "http://sfc02-icge-gl.ipebg.efoxconn.com:8080/sfc_cg_api/mpline/sfc/do_pass";
        public const string LH_URL_PASS_STATION_REPORT = "http://sfc02-icge-lh.ipebg.efoxconn.com:8080/sfc_cg_api/mpline/sfc/do_pass";
        public const string ZZK_URL_PASS_STATION_REPORT = "http://sfc02-icge-zzk.ipebg.efoxconn.com:8080/sfc_cg_api/mpline/sfc/do_pass";
        public const string ZZC_URL_PASS_STATION_REPORT = "http://sfc02-icge-zzc.ipebg.efoxconn.com:8080/sfc_cg_api/mpline/sfc/do_pass";

        public const string GL_URL_DATAUPLOAD_FRAME_WELDING = "http://traceabilityacg-gl.ipebg.efoxconn.com:8081/awisapid808/FrameWelding.do";
        public const string LH_URL_DATAUPLOAD_FRAME_WELDING = "http://traceabilityacg-lh.ipebg.efoxconn.com:8080/awisapid808/FrameWelding.do";
        public const string ZZK_URL_DATAUPLOAD_FRAME_WELDING = "http://traceabilityacg-zzk.ipebg.efoxconn.com:8080/awisapid808/FrameWelding.do";
        public const string ZZC_URL_DATAUPLOAD_FRAME_WELDING = "http://tbcg-zzc.ipebg.efoxconn.com:8080/awisapid808/FrameWelding.do";

        public const string GL_URL_DATAUPLOAD_FRAME_PLASMA = "http://traceabilityacg-gl.ipebg.efoxconn.com:8081/awisapid808/PlasmaData.do";
        public const string LH_URL_DATAUPLOAD_FRAME_PLASMA = "http://traceabilityacg-lh.ipebg.efoxconn.com:8080/awisapid808/PlasmaData.do";
        public const string ZZK_URL_DATAUPLOAD_FRAME_PLASMA = "http://traceabilityacg-zzk.ipebg.efoxconn.com:8080/awisapid808/PlasmaData.do";
        public const string ZZC_URL_DATAUPLOAD_FRAME_PLASMA = "http://tbcg-zzc.ipebg.efoxconn.com:8080/awisapid808/PlasmaData.do";

        public const string GL_URL_DATAUPLOAD_FRAME_PRIMER = "http://traceabilityacg-gl.ipebg.efoxconn.com:8081/awisapid808/PrimerData.do";
        public const string LH_URL_DATAUPLOAD_FRAME_PRIMER = "http://traceabilityacg-lh.ipebg.efoxconn.com:8080/awisapid808/PrimerData.do";
        public const string ZZK_URL_DATAUPLOAD_FRAME_PRIMER = "http://traceabilityacg-zzk.ipebg.efoxconn.com:8080/awisapid808/PrimerData.do";
        public const string ZZC_URL_DATAUPLOAD_FRAME_PRIMER = "http://tbcg-zzc.ipebg.efoxconn.com:8080/awisapid808/PrimerData.do";

        public const string GL_URL_DATAUPLOAD_DISPLAY_MESH_Z = "http://traceabilityacg-gl.ipebg.efoxconn.com:8081/awisapid808/MeshZ.do";
        public const string LH_URL_DATAUPLOAD_DISPLAY_MESH_Z = "http://traceabilityacg-lh.ipebg.efoxconn.com:8080/awisapid808/MeshZ.do";
        public const string ZZK_URL_DATAUPLOAD_DISPLAY_MESH_Z = "http://traceabilityacg-zzk.ipebg.efoxconn.com:8080/awisapid808/MeshZ.do";
        public const string ZZC_URL_DATAUPLOAD_DISPLAY_MESH_Z = "http://tbcg-zzc.ipebg.efoxconn.com:8080/awisapid808/MeshZ.do";

        public const string GL_URL_DATAUPLOAD_DISPLAY_ASSY = "http://traceabilityacg-gl.ipebg.efoxconn.com:8081/awisapid808/GlueData.do";
        public const string LH_URL_DATAUPLOAD_DISPLAY_ASSY = "http://traceabilityacg-lh.ipebg.efoxconn.com:8080/awisapid808/GlueData.do";
        public const string ZZK_URL_DATAUPLOAD_DISPLAY_ASSY = "http://traceabilityacg-zzk.ipebg.efoxconn.com:8080/awisapid808/GlueData.do";
        public const string ZZC_URL_DATAUPLOAD_DISPLAY_ASSY = "http://tbcg-zzc.ipebg.efoxconn.com:8080/awisapid808/GlueData.do";

        public const string GL_URL_DATAUPLOAD_MESH_WELDING = "http://traceabilityacg-gl.ipebg.efoxconn.com:8081/awisapid808/MeshWelding.do";
        public const string LH_URL_DATAUPLOAD_MESH_WELDING = "http://traceabilityacg-lh.ipebg.efoxconn.com:8080/awisapid808/MeshWelding.do";
        public const string ZZK_URL_DATAUPLOAD_MESH_WELDING = "http://traceabilityacg-zzk.ipebg.efoxconn.com:8080/awisapid808/MeshWelding.do";
        public const string ZZC_URL_DATAUPLOAD_MESH_WELDING = "http://tbcg-zzc.ipebg.efoxconn.com:8080/awisapid808/MeshWelding.do";

        public const string GL_URL_DATAUPLOAD_DISPLAY_EMD_ELETRIC = "http://traceabilityacg-gl.ipebg.efoxconn.com:8081/awisapid808/EmdElectric.do";
        public const string LH_URL_DATAUPLOAD_DISPLAY_EMD_ELETRIC = "http://traceabilityacg-lh.ipebg.efoxconn.com:8080/awisapid808/EmdElectric.do";
        public const string ZZK_URL_DATAUPLOAD_DISPLAY_EMD_ELETRIC = "http://traceabilityacg-zzk.ipebg.efoxconn.com:8080/awisapid808/EmdElectric.do";
        public const string ZZC_URL_DATAUPLOAD_DISPLAY_EMD_ELETRIC = "http://tbcg-zzc.ipebg.efoxconn.com:8080/awisapid808/EmdElectric.do";

        public const string GL_URL_DATAUPLOAD_DISPLAY_IQC_CHECK = "http://traceabilityacg-gl.ipebg.efoxconn.com:8081/awisapid808/iqc.do";
        public const string LH_URL_DATAUPLOAD_DISPLAY_IQC_CHECK = "http://traceabilityacg-lh.ipebg.efoxconn.com:8080/awisapid808/iqc.do";
        public const string ZZK_URL_DATAUPLOAD_DISPLAY_IQC_CHECK = "http://traceabilityacg-zzk.ipebg.efoxconn.com:8080/awisapid808/iqc.do";
        public const string ZZC_URL_DATAUPLOAD_DISPLAY_IQC_CHECK = "http://tbcg-zzc.ipebg.efoxconn.com:8080/awisapid808/iqc.do";

        public const string GL_URL_DATAUPLOAD_FRAME_PREnPOST = "http://traceabilityacg-gl.ipebg.efoxconn.com:8081/awisapid808/PrePost.do";
        public const string LH_URL_DATAUPLOAD_FRAME_PREnPOST = "http://traceabilityacg-lh.ipebg.efoxconn.com:8080/awisapid808/PrePost.do";
        public const string ZZK_URL_DATAUPLOAD_FRAME_PREnPOST = "http://traceabilityacg-zzk.ipebg.efoxconn.com:8080/awisapid808/PrePost.do";
        public const string ZZC_URL_DATAUPLOAD_FRAME_PREnPOST = "http://tbcg-zzc.ipebg.efoxconn.com:8080/awisapid808/PrePost.do";

        public const string GL_URL_DATAUPLOAD_FIXTURE_GLUE_TEST = "http://traceabilityacg-gl.ipebg.efoxconn.com:8081/awisapid808/FixtureTest.do";
        public const string LH_URL_DATAUPLOAD_FIXTURE_GLUE_TEST = "http://traceabilityacg-lh.ipebg.efoxconn.com:8080/awisapid808/FixtureTest.do";
        public const string ZZK_URL_DATAUPLOAD_FIXTURE_GLUE_TEST = "http://traceabilityacg-zzk.ipebg.efoxconn.com:8080/awisapid808/FixtureTest.do";
        public const string ZZC_URL_DATAUPLOAD_FIXTURE_GLUE_TEST = "http://tbcg-zzc.ipebg.efoxconn.com:8080/awisapid808/FixtureTest.do";

        public const string GL_URL_DATAUPLOAD_DISPLAY_CLEAN_GLUE = "http://traceabilityacg-gl.ipebg.efoxconn.com:8081/awisapid808/CleanGlue.do";
        public const string LH_URL_DATAUPLOAD_DISPLAY_CLEAN_GLUE = "http://traceabilityacg-lh.ipebg.efoxconn.com:8080/awisapid808/CleanGlue.do";
        public const string ZZK_URL_DATAUPLOAD_DISPLAY_CLEAN_GLUE = "http://traceabilityacg-zzk.ipebg.efoxconn.com:8080/awisapid808/CleanGlue.do";
        public const string ZZC_URL_DATAUPLOAD_DISPLAY_CLEAN_GLUE = "http://tbcg-zzc.ipebg.efoxconn.com:8080/awisapid808/CleanGlue.do";

    }
}
