export function obtenerFechaActual(){
    const fecha = new Date();
    return fecha.toLocaleDateString();
}
export function obtenerHoraActual(){
    const fecha = new Date();
    return fecha.toLocaleTimeString();
}