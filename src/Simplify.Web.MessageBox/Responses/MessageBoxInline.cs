using System.Threading.Tasks;

namespace Simplify.Web.MessageBox.Responses;

/// <summary>
/// Provides inline message box response (generate inline message box and sends it to the user only, without site generation).
/// </summary>
/// <seealso cref="ControllerResponse" />
/// <remarks>
/// Initializes a new instance of the <see cref="Web.MessageBox.Responses.MessageBox" /> class.
/// </remarks>
/// <param name="text">The message box text.</param>
/// <param name="status">The message box status.</param>
public class MessageBoxInline(string text, MessageBoxStatus status = MessageBoxStatus.Error) : ControllerResponse
{
	/// <summary>
	/// Gets the text.
	/// </summary>
	/// <value>
	/// The text.
	/// </value>
	public string Text { get; } = text;

	/// <summary>
	/// Gets the status.
	/// </summary>
	/// <value>
	/// The status.
	/// </value>
	public MessageBoxStatus Status { get; } = status;

	/// <summary>
	/// Executes this response asynchronously.
	/// </summary>
	public override async Task<ResponseBehavior> ExecuteAsync()
	{
		var handler = new MessageBoxHandler(TemplateFactory, StringTableManager, DataCollector);

		await ResponseWriter.WriteAsync(Context.Response, handler.GetInline(Text, Status));

		return ResponseBehavior.RawOutput;
	}
}