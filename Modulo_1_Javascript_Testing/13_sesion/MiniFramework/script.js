function expect(actual){
    return{
        toBo(expected){
            if(actual === expected){
                console.log(`Pasó: ${actual} === ${expected}`);
            }else{
                console.log(`Falló: se esperaba ${expected}, pero se obtuvo ${actual}`);
            }
        },
        toEqual(expected){
            const passed = JSON.stringify(actual) === JSON.stringify(expected);
            if(passed){
                console.log(`Pasó: Objetos iguales.`);
            }else{
                console.log(`Falló: Objetos diferentes.`);
            }
        }
    }
}

function sumar(a, b){
    return a + b;
}

function validarUsuario(usuario){
    return usuario.nombre && /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(usuario.correo);
}

const usuarioValido = {nombre: "Ana", correo: "ana@gmail.com"}
const usuarioInvalido = {nombre: "Ulises", correo: "ulises@mail"}

expect(sumar(1,3)).toBo(5);
expect(sumar(10,0)).toBo(10);

expect(validarUsuario(usuarioValido)).toBo(true);
expect(validarUsuario(usuarioInvalido)).toBo(true);

expect(usuarioValido).toEqual(usuarioInvalido);