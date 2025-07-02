using Newtonsoft.Json;

namespace ServiceAccountingBL.Models.AccountUser.Dto
{
    public class ResponseMainInformationUserAccountDtoBL
    {
        [JsonProperty(PropertyName = "clientInf", Order = 0, Required = Required.Always)]
        public ResponseClientInfDtoBL ClientInf { get; set; }

        [JsonProperty(PropertyName = "clientCardInf", Order = 1, Required = Required.Always)]
        public ResponseClientCardInfDtoBL ClientCardInf { get; set; }
    }
}
