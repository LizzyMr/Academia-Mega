# Sesión 10: Introducción a JavaScript y Testing

## Fecha: 04/04/2025

## Objetivos de la Sesión

- Introducción y Fundamentos de HTML
- Conocer patrones de diseño básicos
- Conocer y aplicar patrones de diseño como Módulo y Singleton, fundamentales para estructurar código mantenible y reutilizable 

## Temas Cubiertos

1. **Fundamentos de HTML**
   - JSON y almacenamiento local
   - Ejemplos de buenas prácticas y depuración 
   - Fundamentos del Testing
   - Patrones de diseño en JavaScript

## Ejercicios Realizados

### Ejercicio 10: Patrón módulo y singleton.

```html
<!-- Actividad.html -->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Actividad  - Clase 10</title>
    <style>
        body{
            font-family:Verdana, Geneva, Tahoma, sans-serif;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            background: linear-gradient(to right, #915DA2, #5D6EA2);
            margin: 0;
        }
        .login-container{
            background-color: white;
            padding: 2rem;
            border-radius: 10px;
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.2);
            width: 300px;
            text-align: center;
        }
        h1{
            margin-bottom: 1.5rem;
            color: #333;
        }
        input[type="text"], input[type="password"]{
            width: 90%;
            padding: 0.75rem;
            margin: 0.5rem 0;
            border: 1px solid #ccc;
            border-radius: 5px;
            transition: border 0.3s;
        }
        input[type="text"]:focus, input[type="password"]:focus{
            border: 1px solid #6F5DA2;
            outline: none;
        }
        button{
            width: 48%;
            padding: 0.75rem;
            border: none;
            border-radius: 5px;
            background-color: #6F5DA2;
            color: white;
            cursor: pointer;
            margin: 0.5rem 0;
        }
        button:hover{
            background-color: #6F5DA2;
        }
        .button-container{
            display: flex;
            justify-content: space-between;
        }
        .popup{
            display: none;
            position: fixed;
            top: 20px;
            right: 20px;
            background-color: #fff;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.2);
            padding: 1rem;
            z-index: 1000;
        }
        .popup.show{
            display: block;
        }
    </style>
</head>
<body>
    <div class="login-container">
        <h1>Login Ficticio</h1>
        <input type="text" id="username" placeholder="Usuario" required>
        <input type="password" id="password" placeholder="Contraseña" required>
        <div class="button-container">
            <button onclick="login()">Iniciar Sesión</button>
            <button onclick="logout()">Cerrar Sesión</button>
        </div>
    </div>
    <div class="popup" id="notification"></div>
    <script src="authModule.js"></script>
    <script src="userSingleton.js"></script>
    <script>
        function showNotification(message){
            const notification = document.getElementById('notification');
            notification.textContent = message;
            notification.classList.add('show');
            setTimeout(() => {
                notification.classList.remove('show');
            }, 3000);
        }

        function login(){
            const user = document.getElementById("username").value;
            const pass = document.getElementById("password").value;

            AuthModule.login(user, pass)
            .then(response => {
                if(response.success){
                    showNotification("Usuario autenticado.");
                }else{
                    showNotification("Credenciales incorrectas.");
                }
            });
        }
        
        function logout(){
            const response = AuthModule.logout();
            showNotification(response.message);
        }
    </script>
</body>
</html>
```

```js - AuthModule.js
//AuthModule.js
const AuthModule = (function(){
    //Simular Usuario
    const userDB = {
        username : "admin",
        password : "1234"
    };

    let currentUser = null;

    return{
        login(username, password){
            return new Promise((resolve) => {
                if(username === userDB.username && password === userDB.password){
                    currentUser = UserSingleton.getInstance(username);
                    console.log(`Usuario Autenticado: ${currentUser.name}`);
                    resolve({ success: true });
                }else{
                    console.log("Credenciales Incorrectas");
                    resolve({ success: false })
                }
            });
        },
        logout(){
            if(currentUser){
                const message = `Sesión finalizada. ¡Hasta luego, ${currentUser.name}!`;
                console.log(message);
                currentUser = null;
                UserSingleton.clearInstance();
                return{message};
            }else{
                const message = "No hay usuario autenticado";
                console.log(message);
                return{message};
            }
        }
    };
})();
```
```js - userSingleton.js
const UserSingleton = (function(){
    let instance = null;

    function createInstance(name){
        return{
            name,
            loginTime: new Date().toLocaleDateString()
        };
    }

    return{
        getInstance(name){
            if(!instance){
                instance = createInstance(name)
            }
            return instance
        },
        clearInstance(){
            instance = null;
        }
    };
})();
```

## Desafíos Encontrados

- **Sin impedimentos** Por el momento no tuve ningún inconveniente al realizar esta actividad.  

## Recursos Adicionales

- [JavaScript Testing Best Practices](https://github.com/goldbergyoni/javascript-testing-best-practices)
- [ES6 Features Overview](https://github.com/lukehoban/es6features)

## Próximos Pasos

- Continuar los avances en cursos de prerrequisitos. 
- Practicar los ejercicios realizados en la sesión.

## Reflexiones Personales

Esta sesión me ha ayudado a recordar conocimientos básicos sobre HTML, CSS y JS, y lo funcional que es dentro de la programación.

---

*Entregable correspondiente a la Semana 3 del Módulo 1: JavaScript Testing*