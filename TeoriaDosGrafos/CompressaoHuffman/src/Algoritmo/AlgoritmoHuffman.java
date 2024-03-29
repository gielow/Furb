package Algoritmo;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Scanner;
import java.util.TreeMap;


public class AlgoritmoHuffman {

	public Arvore montarArvoreDeCompactacao(String texto){
		Map<String, Integer> listaDeFrequencias = SepararPorFrequencia(texto);
		List<NoArvore> nos = new ArrayList<NoArvore>();
		for(Entry<String, Integer> entry : listaDeFrequencias.entrySet()){
			nos.add(new NoArvore(entry.getKey(), entry.getValue()));
		}
		while(nos.size() > 1){
			NoArvore n1 = nos.remove(0);
			NoArvore n2 = nos.remove(0);
			NoArvore newNo = new NoArvore(n1, n2);
			nos.add(newNo);
			Collections.sort(nos);
		}
		return new Arvore(nos.get(0));
	}
	
	public Map<String, Integer> SepararPorFrequencia(String texto) {
		
		Map<String, Integer> lista = new HashMap<String, Integer>();
		
		for(char c: texto.toCharArray()){
			if(lista.containsKey(String.valueOf(c))){
				Integer valor1 = lista.get(String.valueOf(c)) + 1;
				lista.put(String.valueOf(c), valor1);
			}
			else{
				lista.put(String.valueOf(c), 1);
			}
		}
		
		
		ValueComparator comparator =  new ValueComparator(lista);
		Map<String,Integer> listaOrdenada = new TreeMap<String,Integer>(comparator);
		listaOrdenada.putAll(lista);
		return listaOrdenada;
	}

	public Map<String, String> ObterDicionario(Arvore arvore) {
		Map<String, String> dicionario = new HashMap<String, String>();
		for(NoArvore no : arvore.obterNosFolhas()){
			dicionario.put(no.getValor(), no.getCaminho());
		}
		return dicionario;
	}

	public String CompactarInformandoUmaArvore(String texto, Arvore arvore) {
		Map<String, String> dicionario = ObterDicionario(arvore);
		String conteudoCompactado = arvore.toString();
		
		for(int i = 0; i < texto.length(); i++){
			String valor = dicionario.get(String.valueOf(texto.charAt(i)));
			conteudoCompactado += valor;
		}
		
		return conteudoCompactado;
	}
	
	public String CompactarArquivo(String fileName){
		String conteudo;
		try {
			conteudo = new Scanner(new File(fileName)).useDelimiter("\\A").next();
			return CompactarTexto(conteudo);
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return "";
	}

	public String CompactarTexto(String texto) {
		Arvore arvore = montarArvoreDeCompactacao(texto);
		return CompactarInformandoUmaArvore(texto, arvore);
	}

}

class ValueComparator implements Comparator<String> {

    Map<String, Integer> base;
    public ValueComparator(Map<String, Integer> base) {
        this.base = base;
    }
    
    public int compare(String a, String b) {
        if (base.get(a) <= base.get(b)) {
            return -1;
        } else {
            return 1;
        } 
    }
}
