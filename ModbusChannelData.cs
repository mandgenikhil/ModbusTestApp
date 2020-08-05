using System.Collections.Generic;

namespace ModbusTestApp
{
    public class ModbusChannelData
    {
        public List<InstrumentInfo> _instrument_info_list { get; set; }
    }
    public class InstrumentInfo
    {
        public string instrument_IP_Address { get; set; }
        public string instrument_Id { get; set; }
        public List<ChannelData> channel_data { get; set; }
    }
    public class ChannelData
    {
        public int channel_id { get; set; }
        public int channel_value { get; set; }        

        public int high_value_threshold = 50;

        public int low_value_threshold = 10;        
        public bool is_high_value_continue { get; set; }        
        public bool is_low_value_continue { get; set; }
    }

}
