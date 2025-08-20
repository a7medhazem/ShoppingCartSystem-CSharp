# 🛒 Shopping Cart System (Console App - C#)

A simple **console-based Shopping Cart system** built with **C#**.  
This project simulates a mini e-commerce experience where users can add/remove items, view cart contents, undo actions, and proceed to checkout — all from the terminal.  

👉 Created as a **practice project** focusing on **Generics & Collections**.

---

## ✨ Features
- ➕ **Add items to cart** (with validation)  
- ❌ **Remove items from cart** by name  
- 📋 **View cart contents** anytime  
- ⏪ **Undo last action** (add/remove using `Stack`)  
- 💳 **Checkout system** with confirmation & total price  
- 🚪 **Exit program safely**  

---

## 🛠️ Technologies & Concepts
- ⚡ **.NET 8 Console Application**  
- 📦 **Generics & Collections**:  
  - `List<T>` → Cart items  
  - `Dictionary<TKey, TValue>` → Items & Prices  
  - `Stack<T>` → Undo actions  
  - `Tuple` → Paired data (Item, Price)  
- 🔄 **Switch-case menu navigation**  
- 🛡️ **Input validation & error handling**  

---

## 🚀 Getting Started
To run the application locally:

```bash
git clone https://github.com/a7medhazem/ShoppingCartSystem-CSharp.git
cd ShoppingCartSystem-CSharp
dotnet run
```

---

## 📄 License & Author

Created with ❤️ by [a7medhazem](https://github.com/a7medhazem)  
Licensed under the [MIT License](LICENSE.md)
