// Oi

var row1 = new List<int>() { 4, 4, 2 };
var row2 = new List<int>() { 5, 5 };
var row3 = new List<int>() { 3, 2, 5 };

var parede = new List<List<int>> { row1, row2, row3 };

var ret = Main.minimumNumberOfBricksToCut(parede);

Console.WriteLine(ret);

public static class Main
{

    public static int minimumNumberOfBricksToCut(List<List<int>> wall)
    {
        var res = new List<List<int>>();

        /// Complexidade: O(n*m)
        ///     n = número de linhas da parede, m = número maximo de tijolos por linha 
        foreach (var row in wall)
        {
            var summedRow = new List<int>();
            
            var currentSum = 0;

            foreach (var brick in row)
            {
                currentSum += brick;

                summedRow.Add(currentSum);
            }

            res.Add(summedRow);
        }

        var wallHeight = wall.Count;

        /// Cria um Dicionário contendo a posição de cada possível corte como chave, 
        /// para armazenar a qntd de combinações por posição.
        /// 
        /// Complexidade: O(n*m)
        ///     n = tamanho de res, que é igual ao número de linhas da parede, 
        ///     m = número máximo de tijolos por linha
        var allNumbers = res.SelectMany(c => c)
            .Where(c => c > 0 && c < 10)
            .Distinct()
            .ToDictionary(c => c, c => 0);

        /// Complexidade: O(n*m)
        ///     n = tamanho de res, que é igual ao número de linhas da parede, 
        ///     m = número de chaves únicas de allNumbers, que no pior caso será = número máximo de tijolos por linha 
        foreach (var num in allNumbers.Keys)
        {
            foreach (var row in res)
            {
                if (row.Any(c => c == num))
                {
                    allNumbers[num] += 1;
                }
            }
        }

        /// Complexidade: O(n)
        ///     n = número de valores do dicionário
        var maxCombinations = allNumbers.Values.Max();

        return wallHeight - maxCombinations;
    }
}
