using System;
using Simplify.Web.Modules.Data;

namespace Simplify.Web.MessageBox;

/// <summary>
/// Provides the HTML message box.
/// Usable template files:
/// "Simplify.Web/MessageBox/InfoMessageBox.tpl"
/// "Simplify.Web/MessageBox/ErrorMessageBox.tpl"
/// "Simplify.Web/MessageBox/OkMessageBox.tpl"
/// "Simplify.Web/MessageBox/InlineInfoMessageBox.tpl"
/// "Simplify.Web/MessageBox/InlineErrorMessageBox.tpl"
/// "Simplify.Web/MessageBox/InlineOkMessageBox.tpl"
/// Usable <see cref="StringTable" /> items:
/// "FormTitleMessageBox"
/// Template variables:
/// "Message"
/// "Title"
/// </summary>
/// <seealso cref="IMessageBoxHandler" />
/// <remarks>
/// Initializes a new instance of the <see cref="MessageBoxHandler" /> class.
/// </remarks>
/// <param name="templateFactory">The template factory.</param>
/// <param name="stringTable">The string table.</param>
/// <param name="dataCollector">The data collector.</param>
public sealed class MessageBoxHandler(ITemplateFactory templateFactory, IStringTable stringTable, IDataCollector dataCollector) : IMessageBoxHandler
{
	/// <summary>
	/// The message box templates path
	/// </summary>
	public const string MessageBoxTemplatesPath = "App_Packages/Simplify.Web.MessageBox/";

	/// <summary>
	/// Generate message box HTML and set to data collector
	/// </summary>
	/// <param name="text">Text of a message box</param>
	/// <param name="status">Status of a message box</param>
	/// <param name="title">Title of a message box</param>
	public void Show(string? text, MessageBoxStatus status = MessageBoxStatus.Error, string? title = null)
	{
		if (string.IsNullOrEmpty(text))
			throw new ArgumentNullException(nameof(text));

		var templateFile = MessageBoxTemplatesPath;

		templateFile += status switch
		{
			MessageBoxStatus.Information => "InfoMessageBox.tpl",
			MessageBoxStatus.Error => "ErrorMessageBox.tpl",
			MessageBoxStatus.Ok => "OkMessageBox.tpl",
			_ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
		};

		var tpl = templateFactory.Load(templateFile);

		tpl.Set("Message", text);
		tpl.Set("Title", string.IsNullOrEmpty(title) ? stringTable.GetItem("FormTitleMessageBox") : title);

		dataCollector.Add(tpl.Get());
		dataCollector.AddTitle(string.IsNullOrEmpty(title) ? stringTable.GetItem("FormTitleMessageBox") : title);
	}

	/// <summary>
	///Generate message box HTML and set to data collector
	/// </summary>
	/// <param name="stringTableItemName">Show message from string table item</param>
	/// <param name="status">Status of a message box</param>
	/// <param name="title">Title of a message box</param>
	public void ShowSt(string stringTableItemName, MessageBoxStatus status = MessageBoxStatus.Error, string? title = null) =>
		Show(stringTable.GetItem(stringTableItemName), status, title);

	/// <summary>
	/// Get inline message box HTML
	/// </summary>
	/// <param name="text">Text of a message box</param>
	/// <param name="status">Status of a message box</param>
	/// <returns>Message box html</returns>
	public string GetInline(string? text, MessageBoxStatus status = MessageBoxStatus.Error)
	{
		if (string.IsNullOrEmpty(text))
			throw new ArgumentNullException(nameof(text));

		var templateFile = MessageBoxTemplatesPath;

		templateFile += status switch
		{
			MessageBoxStatus.Information => "InlineInfoMessageBox.tpl",
			MessageBoxStatus.Error => "InlineErrorMessageBox.tpl",
			MessageBoxStatus.Ok => "InlineOkMessageBox.tpl",
			_ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
		};

		var tpl = templateFactory.Load(templateFile);

		tpl.Set("Message", text);

		return tpl.Get();
	}

	/// <summary>
	/// Get inline message box HTML
	/// </summary>
	/// <param name="stringTableItemName">Show message from string table item</param>
	/// <param name="status">Status of a message box</param>
	/// <returns>Message box html</returns>
	public string GetInlineSt(string stringTableItemName, MessageBoxStatus status = MessageBoxStatus.Error) =>
		GetInline(stringTable.GetItem(stringTableItemName), status);
}