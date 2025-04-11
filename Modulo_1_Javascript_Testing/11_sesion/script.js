document.getElementById("formularioNotas").addEventListener("submit", function(e){
    e.preventDefault();

    const nota1Str = document.getElementById("nota1").value;
    const nota2Str = document.getElementById("nota2").value;
    const nota3Str = document.getElementById("nota3").value;

    const resultado = document.getElementById("resultado");

    try {
        // Validar si hay campos vacíos
        if (nota1Str === "" || nota2Str === "" || nota3Str === "") {
            throw new Error("Todos los campos tienen que ser llenados.");
        }

        const nota1 = parseFloat(nota1Str);
        const nota2 = parseFloat(nota2Str);
        const nota3 = parseFloat(nota3Str);

        // Validar si son negativos
        if ([nota1, nota2, nota3].some(n => n < 0)) {
            throw new Error("Estas ingresando una nota negativa. Todas las notas deben estar en 0 y 10.");
        }

        const promedio = calcularPromedio(nota1, nota2, nota3);

        resultado.textContent = `El promedio es: ${promedio.toFixed(2)}`;
        resultado.style.color = promedio >= 6 ? "green" : "orange";
    } catch (error) {
        resultado.textContent = error.message;
        resultado.style.color = "red";
    }
});

function calcularPromedio(n1, n2, n3) {
    if ([n1, n2, n3].some(isNaN)) {
        throw new Error("Todas las notas deben ser números válidos.");
    }

    if ([n1, n2, n3].some(n => n > 10)) {
        throw new Error("Todas las notas deben estar entre 0 y 10.");
    }

    return (n1 + n2 + n3) / 3;
}