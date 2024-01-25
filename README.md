### Análise de tempo
1. Temos, na primeira iteração do algoritmo, uma complexidade de tempo de O(n*m), onde n é o tamanho da parede e m é o número máximo de tijolos em uma linha da parede. 
Essa iteração produz como resultado a List `res`, que, por sua vez, tem o mesmo tamanho da parede e o mesmo número de tijolos (mas com valores diferentes).

2. Já na próxima iteração, onde criamos o dictionary `allNumbers`, a List `res` é percorrida juntamente com seus elementos, um a um, para executar o SelectMany e o Distinct. 
Logo, sua complexidade temporal também será de O(n*m), onde n é o tamanho da parede (que também é o tamnho de res) e m é o número máximo de tijolos.

3. Na próxima iteração, temos uma complexidade temporal de O(m*n), onde m é o número de chaves de `allNumbers` 
(que no pior caso, será exatamente igual ao número máximo de tijolos) e n é o tamanho da parede (que também é o tamnho de res).

4. Por fim, em `allNumbers.Values.Max()`, iteramos os Values de allNumbers apenas uma única vez para encontrar o valor máximo, portanto, O(n), onde n é o 
número de valores no dicionário.

Assim, a complexidade de tempo total é: O(3n*m + n) = **O(n*m)**

### Análise de memória
1. Como criamos a lista `summedRow` para cada linha da parede (n), com o tamanho máximo de tijolos (m) e a adicionamos na lista `res`, sua complexidade de memória é de O(n*m).

2. Também criamos o dictionary `allNumbers`, que terá tamanho proporcional ao número de tijolos na parede, pois irá armazenar as posições distintas contidas em `res`.

3. Assim, a complexidade de espaço total é: O(2n*m) = **O(n*m)**