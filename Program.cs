using System.Collections.Generic;

namespace ModbusTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
          var data =   LoadModbusData();
          foreach(var item in data._instrument_info_list)
            {

                foreach(var channelData in item.channel_data)
                {
                    var value = GetStatus(channelData.channel_value,channelData.high_value_threshold,channelData.low_value_threshold);

                    switch (value)
                    {
                        case "Normal":
                            if(channelData.is_high_value_continue == true)
                            {
                                //Raise Alert back to normal
                            }
                            if (channelData.is_low_value_continue == true)
                            {
                                //Raise Alert back to normal

                            }
                            channelData.is_high_value_continue = false;
                            channelData.is_low_value_continue = false;
                            break;
                        case "Low":
                            if(channelData.is_low_value_continue == false)
                            {
                                // Raise an alarm 
                                channelData.is_low_value_continue = true;
                            }
                            break;
                        case "High":
                            if (channelData.is_high_value_continue == false)
                            {
                                // Raise an alarm 
                                channelData.is_high_value_continue = true;
                            }
                            break;
                        default:
                            break;
                    }
                    
                }
            }          
        }

        private static ModbusChannelData LoadModbusData()
        {

            // This will pull/create your Object Data from Modbus
            var _modbusChannelData = new ModbusChannelData();
            _modbusChannelData._instrument_info_list = new List<InstrumentInfo>();

            _modbusChannelData._instrument_info_list.Add(
                new InstrumentInfo()
                {
                    instrument_Id = "1",
                    instrument_IP_Address = "10.4.14.150",
                    channel_data = new List<ChannelData>(),                    
                }) ;
            _modbusChannelData._instrument_info_list[0].channel_data.Add(
                  new ChannelData{
                      channel_id = 0,
                      channel_value = 20,
                      high_value_threshold = 50,
                      low_value_threshold = 10,                                    
            });;

            return _modbusChannelData;

        }
        private static string GetStatus(int value,int high_limit,int low_limit)
        {
            if (value >=high_limit || value<= low_limit )
            {
                return "Normal";
            }
            else if(value> high_limit)
            {
                return "High";
            }
            else if(value < low_limit)
            {

                return "Low";
            }

            return "Normal";

        }
        
    }
}
