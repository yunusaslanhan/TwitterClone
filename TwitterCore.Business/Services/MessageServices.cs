using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitterCore.Business.Context;
using TwitterCore.Business.Services.Interfaces;
using TwitterCore.Common.Dtos;
using TwitterCore.Domain.Entities;

namespace TwitterCore.Business.Services
{
	
	public class MessageServices:IMessageServices
	{
		private TwitterContext _dbContext;


		public MessageServices(IHttpContextAccessor httpAccessor)
		{
			_dbContext = (TwitterContext)httpAccessor.HttpContext.RequestServices.GetService(typeof(TwitterContext));


			
		}


		public void AddMessages(MessageDto messageDto)
		{

			_dbContext.Messages.Add(new Message
			{
				MessageId=messageDto.MessageId,
			   FromId=messageDto.FromId,
			   ToId=messageDto.ToId,
			   MessageText=messageDto.MessageText
			});

			_dbContext.SaveChanges();

		}


		public List<MessageDto> getMessages(int fromId,int toId)
		{

			var listFromMessages=_dbContext.Messages.Where(x => (x.FromId == fromId) && (x.ToId == toId)).Select(m=> new MessageDto { 
				
				FromId=m.FromId,
				MessageId=m.MessageId,
				MessageText=m.MessageText,
				ToId=m.ToId
				
				}).ToList();

			var listToMessages = _dbContext.Messages.Where(x => (x.FromId == toId) && (x.ToId == fromId)).Select(m => new MessageDto
			{

				FromId = m.FromId,
				MessageId = m.MessageId,
				MessageText = m.MessageText,
				ToId = m.ToId

			}).ToList();


			listFromMessages.AddRange(listToMessages);

			return listFromMessages;


		}


	}
}
