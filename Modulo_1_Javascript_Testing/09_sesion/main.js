//Saludo
import {saludar, despedir} from "./saludo.js"
const nombre = "Lizeth";

//Actividad
import {sumar, restar, multiplicar, dividir} from "./actividad.js"

//Fecha
import { obtenerFechaActual, obtenerHoraActual } from "./fecha.js";


//Saludo
console.log(saludar(nombre));
console.log(despedir(nombre));

//Actividad
console.log("Suma: ", sumar(10, 5));
console.log("Resta: ", restar(10, 5));
console.log("Multiplicación: ", multiplicar(10, 5));
console.log("División: ", dividir(10, 5));
console.log("División: ", dividir(10, 0));

//Fecha
console.log("Fecha Actual:", obtenerFechaActual());
console.log("Hora Actual:", obtenerHoraActual());