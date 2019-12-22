using System.Threading.Tasks;

namespace Simplify.Web.MessageBox.Responses
{
	/// <summary>
	/// Provides message box response (generate message box and puts it to the data collector)
	/// </summary>
	public class MessageBox : ControllerResponse
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MessageBox" /> class.
		/// </summary>
		/// <param name="text">The message box text.</param>
		/// <param name="status">The message box status.</param>
		/// <param name="statusCode">The HTTP response status code.</param>
		/// <param name="title">The title.</param>
		public MessageBox(string text, MessageBoxStatus status = MessageBoxStatus.Error, int statusCode = 200, string title = null)
		{
			Text = text;
			Status = status;
			StatusCode = statusCode;
			Title = title;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MessageBox" /> class.
		/// </summary>
		/// <param name="text">The message box text.</param>
		/// <param name="statusCode">The HTTP response status code.</param>
		/// <param name="status">The message box status.</param>
		public MessageBox(string text, int statusCode, MessageBoxStatus status = MessageBoxStatus.Error)
		{
			Text = text;
			StatusCode = statusCode;
			Status = status;
		}

		/// <summary>
		/// Gets the text.
		/// </summary>
		/// <value>
		/// The text.
		/// </value>
		public string Text { get; }

		/// <summary>
		/// Gets the status.
		/// </summary>
		/// <value>
		/// The status.
		/// </value>
		public MessageBoxStatus Status { get; }

		/// <summary>
		/// Gets the HTTP response status code.
		/// </summary>
		/// <value>
		/// The HTTP response status code.
		/// </value>
		public int StatusCode { get; }

		/// <summary>
		/// Gets the title.
		/// </summary>
		/// <value>
		/// The title.
		/// </value>
		public string Title { get; }

		/// <summary>
		/// Processes this response
		/// </summary>
		/// <returns></returns>
		public override Task<ControllerResponseResult> Process()
		{
			Context.Response.StatusCode = StatusCode;

			var handler = new MessageBoxHandler(TemplateFactory, StringTableManager, DataCollector);

			handler.Show(Text, Status, Title);

			return Task.FromResult(ControllerResponseResult.Default);
		}
	}
}