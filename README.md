# APIAuth

Este projeto demonstra conceitos de autenticação e autorização utilizando JWT em APIs construídas com ASP.NET Core. O foco está em mostrar como aplicar políticas customizadas de autorização com base em claims como `role`, `scope` e `sub`.

## 📂 Postman Collection

O arquivo [`API Auth.postman_collection.json`](./API%20Auth.postman_collection.json) disponível neste repositório é uma **collection do Postman** para facilitar os testes dos endpoints protegidos por autenticação e diferentes níveis de autorização.

## 🖥️ Apresentação

Essa aplicação foi utilizada como base para a palestra **"Segurança real em APIs – muito além do JWT"**, apresentada no:

📅 **2º Encontro 2025 do .NET Curitiba**  
📍 **Data:** 30 de abril de 2025  
🔗 **Evento:** [https://www.sympla.com.br/evento/2-encontro-2025-net-curitiba/2872310](https://www.sympla.com.br/evento/2-encontro-2025-net-curitiba/2872310)

🎤 **Apresentação completa no Canva:**  
[https://www.canva.com/design/DAGk7iWDwjM/Et69-Xnts44ug6AXFiKTmQ/edit?utm_content=DAGk7iWDwjM&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton](https://www.canva.com/design/DAGk7iWDwjM/Et69-Xnts44ug6AXFiKTmQ/edit?utm_content=DAGk7iWDwjM&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton)

## ⚙️ Tecnologias

- ASP.NET Core 8
- [https://www.postman.com/](Postman para testes)
 - [https://jwt.io](jwt.io) para destrinchar o token
- JWT Bearer Authentication
- Políticas de autorização com Claims