using System;
using KafkaNet.Model;

namespace KafkaNet
{
    public class BrokerRoute
    {
        public event Action<InstrumentationBrokerData> OnInstrumentationBrokerSendCompleted;

        public BrokerRoute(string topic, int partitionId, IKafkaConnection connection)
        {
            Topic = topic;
            PartitionId = partitionId;
            Connection = connection;
            connection.OnDataSendCompleted += CollectSendData;

        }

        public string Topic { get; private set; }
        public int PartitionId { get; private set; }
        public IKafkaConnection Connection { get; private set; }
        
        public override string ToString()
        {
            return string.Format("{0} Topic:{1} PartitionId:{2}", Connection.Endpoint.ServeUri, Topic, PartitionId);
        }

        private void CollectSendData(InstrumentationSendData sendData)
        {
            if (OnInstrumentationBrokerSendCompleted != null)
            {
                OnInstrumentationBrokerSendCompleted(new InstrumentationBrokerData
                {
                    Topic = Topic,
                    PartitionId = PartitionId,
                    WireData = sendData
                });
            }
        }

        #region Equals Override...
        protected bool Equals(BrokerRoute other)
        {
            return string.Equals(Topic, other.Topic) && PartitionId == other.PartitionId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Topic != null ? Topic.GetHashCode() : 0) * 397) ^ PartitionId;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BrokerRoute)obj);
        }
        #endregion
    }
}