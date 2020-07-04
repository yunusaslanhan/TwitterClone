using System;
using System.Collections.Generic;
using System.Text;
using TwitterCore.Common.Dtos;

namespace TwitterCore.Business.Services.Interfaces
{
	public interface IMessageServices
	{
		void AddMessages(MessageDto messageDto);

		List<MessageDto> getMessages(int fromId, int toId);
	}
}
