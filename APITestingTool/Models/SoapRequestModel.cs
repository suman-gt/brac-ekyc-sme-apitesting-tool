namespace APITestingTool.Models
{
    public class SoapRequestModel
    {

        public string  SoapAction { get; set; }
        public string SoapNamespace { get; set; }
        public string SoapBody { get; set; }
        public string Response { get; set; }
    }
}
