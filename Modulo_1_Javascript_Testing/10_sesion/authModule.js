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