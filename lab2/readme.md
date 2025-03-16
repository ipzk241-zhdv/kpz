# Task 1: Subscription Factory Library

Ця бібліотека реалізує патерн Фабричний метод (Factory Method) для створення різних типів підписок відео-провайдера.

### Основні можливості:
- Створення різних типів підписок:
  - DomesticSubscription (Домашня підписка)
  - EducationalSubscription (Освітня підписка)
  - PremiumSubscription (Преміум підписка)
- Придбання підписок через різні канали:
  - WebSite (Вебсайт)
  - MobileApp (Мобільний додаток)
  - ManagerCall (Дзвінок менеджера)

## Використання Фабричного Методу
Фабричний метод використовується для створення підписок у залежності від каналу придбання.
Він дозволяє інкапсулювати логіку створення об'єктів і спрощує розширення системи.
Фабричний метод визначений у базовому класі `SubscriptionFactory`:

```csharp
public abstract class SubscriptionFactory
{
    public abstract Subscription CreateSubscription();
}
```
Кожен підклас (WebSite, MobileApp, ManagerCall) реалізує цей метод по-своєму:
```csharp
public class WebSite : SubscriptionFactory
{
    public override Subscription CreateSubscription()
    {
        return new DomesticSubscription();
    }
}
```
Коли користувач купує підписку через вебсайт, викликається фабричний метод:
```csharp
SubscriptionFactory factory = new WebSite();
Subscription mySubscription = factory.CreateSubscription();
```

Цей підхід дозволяє легко додавати нові типи підписок та способи їх придбання без зміни існуючого коду.