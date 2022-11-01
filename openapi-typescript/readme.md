# Setup
```bash
wsl
apt update
apt install openjdk-17-jre-headless
apt install nodejs
npm install @openapitools/openapi-generator-cli
```

# Generation
```bash
openapi-generator-cli batch ./typescript-fetch.yaml
```

# Test
```bash
cd out
npm i 
cd ..
npx ts-node ./test.ts   
```