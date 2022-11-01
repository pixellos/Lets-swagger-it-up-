import { InheritanceApi, Configuration } from './out/dist'

const c= new Configuration({basePath: 'http://localhost:5999'})
const api = new InheritanceApi(c);
const result = api.myCustomOpId({ myCustomOpIdRequest: {discriminator: 'Wolf', woof: 'Woof! Woof!'}});
result.then(x => { 
    console.log(x);
    console.log(x.value);
})
