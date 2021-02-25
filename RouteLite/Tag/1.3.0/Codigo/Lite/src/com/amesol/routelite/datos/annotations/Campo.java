package com.amesol.routelite.datos.annotations;

import java.lang.annotation.ElementType;
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.Target;

import com.amesol.routelite.utilerias.Generales;

@Retention(RetentionPolicy.RUNTIME)
@Target(ElementType.FIELD)
public @interface Campo {
	String nombreCampo() default "";
	String msgDescripcion() default "";
}
