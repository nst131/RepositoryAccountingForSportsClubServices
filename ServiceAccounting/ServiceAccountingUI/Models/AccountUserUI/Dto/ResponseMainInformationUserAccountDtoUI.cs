using Newtonsoft.Json;
using ServiceAccountingBL.Models.AccountUser.Dto;

namespace ServiceAccountingUI.Models.AccountUserUI.Dto
{
    public class ResponseMainInformationUserAccountDtoUI
    {
        [JsonProperty(PropertyName = "clientInf", Order = 0, Required = Required.Always)]
        public ResponseClientInfDtoBL ClientInf { get; set; }

        [JsonProperty(PropertyName = "clientCardInf", Order = 1, Required = Required.Always)]
        public ResponseClientCardInfDtoBL ClientCardInf { get; set; }
    }
}
