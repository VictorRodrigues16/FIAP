﻿namespace CheckPoint1;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("1. Testando DemonstrarTiposDados...");
        Console.WriteLine(DemonstrarTiposDados());

        Console.WriteLine("\n2. Testando CalculadoraBasica (SWITCH)...");
        Console.WriteLine(CalculadoraBasica(10, 5, '+'));

        Console.WriteLine("\n3. Testando ValidarIdade (IF/ELSE)...");
        Console.WriteLine(ValidarIdade(25));

        Console.WriteLine("\n4. Testando ConverterString...");
        Console.WriteLine(ConverterString("123", "int"));

        Console.WriteLine("\n5. Testando ClassificarNota (SWITCH)...");
        Console.WriteLine(ClassificarNota(8.5));

        Console.WriteLine("\n6. Testando GerarTabuada (FOR)...");
        Console.WriteLine(GerarTabuada(5));

        Console.WriteLine("\n7. Testando JogoAdivinhacao (WHILE)...");
        Console.WriteLine(JogoAdivinhacao(50, new int[] { 25, 75, 50 }));

        Console.WriteLine("\n8. Testando ValidarSenha (DO-WHILE)...");
        Console.WriteLine(ValidarSenha("MinhaSenh@123"));

        Console.WriteLine("\n9. Testando AnalisarNotas (FOREACH)...");
        Console.WriteLine(AnalisarNotas(new double[] { 8.5, 7.0, 9.2, 6.5, 10.0 }));

        Console.WriteLine("\n10. Testando ProcessarVendas (FOREACH múltiplo)...");
        Console.WriteLine(ProcessarVendas(
            new double[] { 1000, 800, 500 },
            new string[] { "A", "B", "C" },
            new double[] { 0.10, 0.07, 0.05 },
            new string[] { "A", "B", "C" }
        ));

        Console.WriteLine("\n=== RESUMO: TODAS AS ESTRUTURAS FORAM TESTADAS ===");
        Console.ReadKey();
    }

    private static string DemonstrarTiposDados()
    {
        int numero = 42;
        double decimalzinho = 3.14;
        bool verdade = true;
        char letra = 'A';
        string texto = "Olá";
        return $"Inteiro: {numero}, Decimal: {decimalzinho}, Booleano: {verdade}, Caractere: {letra}, Texto: {texto}";
    }

    private static double CalculadoraBasica(double num1, double num2, char operador)
    {
        switch (operador)
        {
            case '+': return num1 + num2;
            case '-': return num1 - num2;
            case '*': return num1 * num2;
            case '/': return num2 == 0 ? 0 : num1 / num2;
            default: return -1;
        }
    }

    private static string ValidarIdade(int idade)
    {
        if (idade < 0 || idade > 120) return "Idade inválida";
        else if (idade < 12) return "Criança";
        else if (idade < 18) return "Adolescente";
        else if (idade <= 65) return "Adulto";
        else return "Idoso";
    }

    private static string ConverterString(string valor, string tipoDesejado)
    {
        if (tipoDesejado == "int")
        {
            if (int.TryParse(valor, out int resultado)) return $"Tipo: int, Valor: {resultado}";
            else return "Conversão impossível para int";
        }
        else if (tipoDesejado == "double")
        {
            if (double.TryParse(valor, out double resultado)) return $"Tipo: double, Valor: {resultado}";
            else return "Conversão impossível para double";
        }
        else if (tipoDesejado == "bool")
        {
            if (bool.TryParse(valor, out bool resultado)) return $"Tipo: bool, Valor: {resultado}";
            else return "Conversão impossível para bool";
        }
        return "Tipo inválido";
    }

    private static string ClassificarNota(double nota)
    {
        switch (nota)
        {
            case >= 9 and <= 10: return "Excelente";
            case >= 7 and < 9: return "Bom";
            case >= 5 and < 7: return "Regular";
            case >= 0 and < 5: return "Insuficiente";
            default: return "Nota inválida";
        }
    }

    private static string GerarTabuada(int numero)
    {
        if (numero <= 0) return "Número inválido";
        string resultado = "";
        for (int i = 1; i <= 10; i++)
        {
            resultado += $"{numero} x {i} = {numero * i}\n";
        }
        return resultado;
    }

    private static string JogoAdivinhacao(int numeroSecreto, int[] tentativas)
    {
        string resultado = "";
        int i = 0;
        while (i < tentativas.Length)
        {
            int palpite = tentativas[i];
            if (palpite < numeroSecreto) resultado += $"Tentativa {i + 1}: {palpite} - muito baixo\n";
            else if (palpite > numeroSecreto) resultado += $"Tentativa {i + 1}: {palpite} - muito alto\n";
            else { resultado += $"Tentativa {i + 1}: {palpite} - correto!\n"; break; }
            i++;
        }
        return resultado;
    }

    private static string ValidarSenha(string senha)
    {
        string erros = "";
        int i = 0;
        do
        {
            if (senha.Length < 8) erros += "Senha deve ter pelo menos 8 caracteres\n";
            if (!senha.Any(char.IsDigit)) erros += "Senha deve ter pelo menos 1 número\n";
            if (!senha.Any(char.IsUpper)) erros += "Senha deve ter pelo menos 1 letra maiúscula\n";
            if (!senha.Any(ch => "!@#$%&*".Contains(ch))) erros += "Senha deve ter pelo menos 1 caractere especial\n";
            i++;
        } while (i < 1);
        if (erros == "") return "Senha válida";
        return erros;
    }

    private static string AnalisarNotas(double[] notas)
    {
        if (notas == null || notas.Length == 0) return "Nenhuma nota para analisar";
        double soma = 0;
        int aprovados = 0;
        double maior = double.MinValue;
        double menor = double.MaxValue;
        int A = 0, B = 0, C = 0, D = 0, F = 0;
        foreach (double n in notas)
        {
            soma += n;
            if (n >= 7) aprovados++;
            if (n > maior) maior = n;
            if (n < menor) menor = n;
            if (n >= 9) A++;
            else if (n >= 8) B++;
            else if (n >= 7) C++;
            else if (n >= 5) D++;
            else F++;
        }
        double media = soma / notas.Length;
        return $"Média: {media}\nAprovados: {aprovados}\nMaior: {maior}\nMenor: {menor}\nA: {A}, B: {B}, C: {C}, D: {D}, F: {F}";
    }

    private static string ProcessarVendas(double[] vendas, string[] categorias, double[] comissoes, string[] nomesCategorias)
    {
        string resultado = "";
        for (int i = 0; i < nomesCategorias.Length; i++)
        {
            double totalVendas = 0;
            double totalComissao = 0;
            for (int j = 0; j < vendas.Length; j++)
            {
                if (categorias[j] == nomesCategorias[i])
                {
                    totalVendas += vendas[j];
                    totalComissao += vendas[j] * comissoes[i];
                }
            }
            resultado += $"Categoria {nomesCategorias[i]}: Vendas R$ {totalVendas}, Comissão R$ {totalComissao}\n";
        }
        return resultado;
    }
}
