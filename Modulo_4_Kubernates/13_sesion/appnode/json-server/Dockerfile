FROM node:20-alpine

WORKDIR /app

# Copiamos primero solo los archivos de dependencias
COPY package*.json ./

# Evitamos que husky falle en la instalación sobrescribiendo el script "prepare"
RUN sed -i 's/"prepare": *".*"/"prepare": "echo Skipping prepare in Docker"/' package.json || true

# Instalamos dependencias (todas: dev + prod)
RUN npm install

# Copiamos el resto del proyecto
COPY . .

# Compilamos TypeScript
RUN npm run build

# Exponemos el puerto que usa la app
EXPOSE 3000

# Ejecutamos la app compilada
CMD ["node", "dist/index.js"]
