namespace KafkaNet.Model
{
    public class InstrumentationBrokerData
    {
        public string Topic { get; set; }
        public int PartitionId { get; set; }
        public InstrumentationSendData WireData { get; set; }
    }

    public class InstrumentationSendData
    {
        public KafkaEndpoint KafkaEndpoint { get; set; }
        public string ClientId { get; set; }
        public int MessageSize { get; set; }
    }
}
