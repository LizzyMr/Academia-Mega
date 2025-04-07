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