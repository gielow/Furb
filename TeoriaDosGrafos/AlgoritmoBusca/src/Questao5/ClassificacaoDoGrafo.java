//DANIEL GIELOW JUNIOR

package Questao5;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class ClassificacaoDoGrafo {
	public String tipoDoGrafo(int[][] matriz){
		boolean completo = true;
		for(int i = 0; i < matriz.length; i++){
			for(int j = 0; j < matriz[i].length; j++){
				if(i != j && matriz[i][j] != 1){
					completo = false;
				}
			}
		}
		if(completo){
			return "completo";
		}
		
		boolean nulo = true;
		for(int i = 0; i < matriz.length; i++){
			for(int j = 0; j < matriz[i].length; j++){
				if(matriz[i][j] != 0){
					nulo = false;
				}
			}
		}
		if(nulo){
			return "nulo";
		}
		boolean regular = true;
		int grauVertice1 = 0;
		if(matriz.length > 0){
			for(int j = 0; j < matriz[0].length; j++){
				grauVertice1 += matriz[0][j];
			}
		}
		for(int i = 0; i < matriz.length; i++){
			int grauVerticeAtual = 0;
			for(int j = 0; j < matriz[i].length; j++){
				grauVerticeAtual += matriz[i][j];
			}
			if(grauVerticeAtual != grauVertice1){
				regular = false;
			}
		}
		if(regular){
			return "regular";
		}
		return "Sem categoria";
	}

	public String arestasDoGrafo(int[][] matriz) {
		int qtdArestas = 0;
		List<String> arestas = new ArrayList<String>();
		for(int i = 0; i < matriz.length; i++){
			for(int j = i; j < matriz[i].length; j++){
				if(matriz[i][j] != 0){
					for(int a = 0; a < matriz[i][j]; a++){
						qtdArestas++;
						arestas.add("(" + (i + 1) + "," + (j + 1) + ")");
					}
				}
			}
		}
		
		String sArestas = qtdArestas + " - E = {";
		for(String aresta : arestas){
			sArestas += aresta + ",";
			
		}
		sArestas = sArestas.substring(0, sArestas.length() -1);
		sArestas += "}";
		return sArestas;
	}

	public String grausDoVertice(int[][] matriz) {
		int[] graus = new int[matriz.length];
		for(int i = 0; i < matriz.length; i++){
			Integer somaGrau = 0;
			for(int j = 0; j < matriz[i].length; j++){
				somaGrau += matriz[i][j];
			}
			graus[i] = somaGrau;
		}
		
		String retorno = "";
		for (int i = 0; i < graus.length; i++) {
			retorno += "g" + (i+1) + "=" + graus[i] + ",";
		}
		retorno = retorno.substring(0, retorno.length() -1) + " - ";
		
		Arrays.sort(graus);
		for(int i = 0; i < graus.length; i++){
			retorno += graus[i] + " ";
		}
		return retorno.substring(0, retorno.length() -1);
	}
}
