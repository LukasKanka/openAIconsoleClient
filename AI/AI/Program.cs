using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using System.Reflection;

List<ChatMessage> messages = new();
messages.Add(new ChatMessage(ChatMessageRole.System, "Odpovídej v bodech"));
Console.WriteLine("Nazdárek jsem tvá osobní AI, co tě zajímá?");


while (true)
{

    string question = Console.ReadLine();
    messages.Add(new ChatMessage(ChatMessageRole.User, question));


    var ai = new OpenAIAPI(new APIAuthentication("Jsem vložíš API key", "Jsem vložíš Organization ID"));

    ChatRequest request = new ChatRequest();
    request.user = "Jsem vlož uživatele(pokud v organizaci je vás více)";
    request.Model = Model.ChatGPTTurbo;
    request.Messages = messages;
    request.Temperature = 0.7;
    request.MaxTokens = 500;




    var response = await ai.Chat.CreateChatCompletionAsync(request);
    string answer = response.Choices.FirstOrDefault().Message.Content;
    messages.Add(response.Choices.FirstOrDefault().Message);
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(answer);
    Console.ResetColor();
}