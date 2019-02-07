#include<stdio.h>
#include<string.h>
#include<ctype.h>

int removerepeated(int size,int a[]);
int insertelementat(int position,int a[],int size);

int main(int argc, char *argv[])
{
	int i,j,k;
	int kelime_numara[100],sifre_numara[100],anahtar_numara[100];
	int anahtar_uzunluk,gecici_boy,bayrak=-1,boyut,boy_kelime;
	int tempkey[100],anahtar_matris[5][5];
	int satir1,satir2,sutun1,sutun2;
	char alinan_kelime[100],anahtar[100];
	
	printf("SIFRELENECEK KELIMEYI GIRINIZ : ");
	gets(alinan_kelime);
	//converting entered string to Capital letters
	
	//KULLANICIDAN ALINAN KELIMEDE BOSLUKLARI ALMADAN
	//BUYUK HARF YAPMA ISLEMIDIR.
	for( i=0,j=0;i<strlen(alinan_kelime);i++ )
	{
		if( alinan_kelime[i]!=' ' )
		{	//toupper:Karakteri büyük harfe çevirir
		   alinan_kelime[j]=toupper(alinan_kelime[i]);   
		   j++;
	  	}
	}
	alinan_kelime[j]='\0';
	
	printf("SIFRELENECEK KELIME : %s\n",alinan_kelime);
	//Storing string in terms of ascii and to restore
	//spaces I used -20
	
	boyut = strlen(alinan_kelime);
	for( i=0;i<boyut;i++ )
	{
		if( alinan_kelime[i]!=' ' )
	    kelime_numara[i] = alinan_kelime[i] - 'A';
	}
	
	boy_kelime = i;
	//Key processing
	printf("ANAHTARI GIRINIZ ");
	printf("(TEKRARLANAN HARFLER ICEREBILIR): ");
	gets(anahtar);
	//converting entered key to Capital letters
	
	for(i=0,j=0;i<strlen(anahtar);i++)
	{
	  	if(anahtar[i]!=' ')
	  	{
	  		anahtar[j]=toupper(anahtar[i]);   
	    	j++;
	    }
	}
	anahtar[j]='\0';
	printf("KULLANILACAK ANAHTAR : %s\n",anahtar);
	
	//Storing key in terms of ascii
	k=0;
	for( i=0;i<strlen(anahtar)+26;i++ )
	{
	    if( i<strlen(anahtar) )
	  	{
		   	if( anahtar[i]=='J' )
		   	{
		   		bayrak=8;
		    	printf("%d",bayrak);
		    }
			anahtar_numara[i] = anahtar[i]-'A';   
	  	}
		else
		{	//Considering I=J and taking I in place of J
			//except when J is there in key ignoring I
		    if ( k!=9 && k!=bayrak )
		        anahtar_numara[i] = k; 
			k++;
		}
	}
	
	gecici_boy = i;
	anahtar_uzunluk = removerepeated(gecici_boy,anahtar_numara);
	printf("PLAYFAIR TOPLAM ANAHTAR : ");
	for( i=0;i<anahtar_uzunluk;i++ )
	{
	    printf("%c",anahtar_numara[i] + 'A');  
	}
	printf("\n");
	//Arranging the key in 5x5 grid
	
	k=0;
	for(i=0;i<5;i++)
	  	for(j=0;j<5;j++)
	  	{
	   		anahtar_matris[i][j] = anahtar_numara[k];   
	   		k++;
	 	}
 
 	printf("------------------------------\n");
 	printf("PLAYFAIR ANAHTARIN MATRIS HALI\n");
 	for(i=0;i<5;i++)
 	{
  		for(j=0;j<5;j++)
   			printf("%c ",anahtar_matris[i][j] + 'A');
   			
  		printf("\n");
	}
   
   //Message Processing
 
   for(i=0;i<boy_kelime;i+=2)
   {
      	if( kelime_numara[i]==kelime_numara[i+1] )
      	{
       		insertelementat(i+1,kelime_numara,boy_kelime);
       		boy_kelime++;
      	}
   }
   
   if( boy_kelime%2!=0 )
   {
    	insertelementat(boy_kelime,kelime_numara,boy_kelime);
    	boy_kelime++;
   }
   
   printf("------------------------------\n");
   printf("PLAYFAIR SIFRELENECEK METIN : ");

   for( i=0;i<boy_kelime;i++ )
   {
		printf("%c",kelime_numara[i]+'A');
		if( (i+1)%2==0 ) printf(" ");
   }
   
   for( k=0;k<boy_kelime;k+=2 )
   {
		for(i=0;i<5;i++)
     		for(j=0;j<5;j++)
     		{
      			if( kelime_numara[k]==anahtar_matris[i][j] )
      			{
         			satir1=i;
         			sutun1=j;       
      			}
      			if( kelime_numara[k+1]==anahtar_matris[i][j] )
      			{
         			satir2=i;
         			sutun2=j;       
      			}
     		}
						
    //Only change between Ecryption to decryption is changing + to -
    //If negative add 5 to that row or column
    	if( satir1 == satir2 )
    	{
     		sutun1=(sutun1-1)%5;
     		sutun2=(sutun2-1)%5;
     		
			if(sutun1<0)
      			sutun1=5+sutun1;

     		if(sutun2<0)
      			sutun2=5+sutun2;
      			
     		sifre_numara[k] = anahtar_matris[satir1][sutun1];
     		sifre_numara[k+1] = anahtar_matris[satir2][sutun2];
    	}
    	
    	if( sutun1==sutun2 )
    	{
     		satir1 = (satir1-1)%5;
     		satir2 = (satir2-1)%5;
     		
      		if(satir1<0)
      			satir1=5+satir1;
      			
     		if(satir2<0)
      			satir2=5+satir2;

     		sifre_numara[k]=anahtar_matris[satir1][sutun1];
     		sifre_numara[k+1]=anahtar_matris[satir2][sutun2];
    	}
    	
    	if( satir1!=satir2 && sutun1!=sutun2 )
    	{
     		sifre_numara[k]=anahtar_matris[satir1][sutun2];
     		sifre_numara[k+1]=anahtar_matris[satir2][sutun1];
    	}
    } 
   
   	printf("\nPLAYFAIR SIFRELENMIS METIN  : ");
   	for(i=0;i<boy_kelime;i++)
   	{   //Should remove extra 'X' which were created during Encryption
    	if( (sifre_numara[i]+'A')!='X' )
      	{
      		printf("%c", sifre_numara[i]+'A' );
      		if( (i+1)%2==0 ) printf(" ");
		}	
   	}
   	
   	printf("\n------------------------------\n");
   	printf("SIFRELENMIS KELIME : ");
   	//Should remove extra 'X' which were created during Encryption
   	for(i=0;i<boy_kelime;i++)
    	if((sifre_numara[i]+'A')!='X')
      		printf("%c",sifre_numara[i]+'A');
   	
  	printf("\n");
}

int removerepeated (int size,int a[])
{
 	int i,j,k;
 	for( i=0;i<size;i++ )
 		for(j=i+1;j<size;)
 		{
    		if(a[i]==a[j])
    		{ 
    			for(k=j;k<size;k++)
					a[k]=a[k+1];
					
         		size--;
        	}
    		else
    		{
      			j++;
     		} 
 		}
 	
	return(size);
	return 0;
}

int insertelementat ( int position,int a[],int size )
{
    int i,insitem=23,temp[size+1];
    for(i=0;i<=size;i++)
    {
        if(i<position)
            temp[i]=a[i];

        if(i>position)
         temp[i]=a[i-1];    

        if(i==position)
            temp[i]=insitem;
    }
        
    for(i=0;i<=size;i++)
    	a[i]=temp[i];
}
