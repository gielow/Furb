package test;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.JUnit4;

import EngarrafamentoDanielGielowJr.Engarrafamento;


@RunWith(JUnit4.class)
public class EngarrafamentoTeste {
	
	@Test
	public void buscarSaidasDoExemploUtilizandoLista(){
		List<String> entradas = new ArrayList<String>();
		entradas.add("3 3");
		entradas.add("1 2 2");
		entradas.add("1 3 7");
		entradas.add("2 3 3");
		entradas.add("1 3");
		entradas.add("3 3");
		entradas.add("1 2 3");
		entradas.add("1 3 7");
		entradas.add("2 3 5");
		entradas.add("1 3");
		entradas.add("3 2");
		entradas.add("1 2 2");
		entradas.add("2 1 3");
		entradas.add("1 3");
		entradas.add("4 6");
		entradas.add("1 2 5");
		entradas.add("1 3 3");
		entradas.add("2 4 3");
		entradas.add("3 2 2");
		entradas.add("4 1 4");
		entradas.add("4 3 9");
		entradas.add("2 3");
		entradas.add("3 3");
		entradas.add("1 2 2");
		entradas.add("1 3 7");
		entradas.add("2 3 3");
		entradas.add("2 2");
		entradas.add("0 0");
		
		Engarrafamento.ObterCaminhos(entradas);	
	}
	
	@Test
	public void buscarSaidasDoExemploUtilizandoStringBuilder(){
		StringBuilder entradas = new StringBuilder();
		entradas.append("3 3");
		entradas.append("\n");
		entradas.append("1 2 2");
		entradas.append("\n");
		entradas.append("1 3 7");
		entradas.append("\n");
		entradas.append("2 3 3");
		entradas.append("\n");
		entradas.append("1 3");
		entradas.append("\n");
		entradas.append("3 3");
		entradas.append("\n");
		entradas.append("1 2 3");
		entradas.append("\n");
		entradas.append("1 3 7");
		entradas.append("\n");
		entradas.append("2 3 5");
		entradas.append("\n");
		entradas.append("1 3");
		entradas.append("\n");
		entradas.append("3 2");
		entradas.append("\n");
		entradas.append("1 2 2");
		entradas.append("\n");
		entradas.append("2 1 3");
		entradas.append("\n");
		entradas.append("1 3");
		entradas.append("\n");
		entradas.append("4 6");
		entradas.append("\n");
		entradas.append("1 2 5");
		entradas.append("\n");
		entradas.append("1 3 3");
		entradas.append("\n");
		entradas.append("2 4 3");
		entradas.append("\n");
		entradas.append("3 2 2");
		entradas.append("\n");
		entradas.append("4 1 4");
		entradas.append("\n");
		entradas.append("4 3 9");
		entradas.append("\n");
		entradas.append("2 3");
		entradas.append("\n");
		entradas.append("3 3");
		entradas.append("\n");
		entradas.append("1 2 2");
		entradas.append("\n");
		entradas.append("1 3 7");
		entradas.append("\n");
		entradas.append("2 3 3");
		entradas.append("\n");
		entradas.append("2 2");
		entradas.append("\n");
		entradas.append("0 0");
		
		Engarrafamento.ObterCaminhos(entradas);
	}
}
