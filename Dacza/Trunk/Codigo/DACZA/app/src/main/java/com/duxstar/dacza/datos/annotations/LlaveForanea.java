package com.duxstar.dacza.datos.annotations;

import java.lang.annotation.ElementType;
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.Target;

@Retention(RetentionPolicy.RUNTIME)
@Target(ElementType.FIELD)
public @interface LlaveForanea {
	String nombreCampo() default "";
	Class<?> tablaPadre();	
	String nombreCampoForaneo();
}
