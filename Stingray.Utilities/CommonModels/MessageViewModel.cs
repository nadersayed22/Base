using StingRay.Utility.CommonEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StingRay.Utility.CommonModels
{
    public class MessageViewModel
    {
        public string Message { get; set; }
        public string Type { get; set; }
        public string OutputParameter { get; set; }
        public int RowCount { get; set; }
        public Guid Id { get; set; }
        public List<string> Errors { get; set; }
        public static MessageViewModel GetMessage(string message, MessageType type = MessageType.Success)
        {
            return new MessageViewModel
            {
                Message = message,
                Type = type.ToString(),
                //Title = type == MessageType.Success ? RM.Messages.Success : RM.Messages.Error
            };
        }
        public static MessageViewModel GetMessage(string message, MessageType type = MessageType.Success, int rowCount = 0)
        {
            return new MessageViewModel
            {
                Message = message,
                Type = type.ToString(),
                RowCount = rowCount,
                //Title = type == MessageType.Success ? RM.Messages.Success : RM.Messages.Error
            };
        }
    }

}
