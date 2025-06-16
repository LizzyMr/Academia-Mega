using TaskManager.Shared.Domain;

namespace TaskManager.Shared.Events; // ✅ Correcto

public record TaskEvent(string EventName, TaskItem Payload);
