import React from 'react';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import Link from 'next/link';
import InforList, { IInforItem } from '@/components/ui/InforList';
import VideocamIcon from '@mui/icons-material/Videocam';
import MovieIcon from '@mui/icons-material/Movie';
import PersonIcon from '@mui/icons-material/Person';

export interface IHoverInfor {
    name: string;
    detail: string;
    author: string;
    categories: string[];
    performer: string[];
    info: IInforItem;
}

const HoverInfor = ({ item, index }: { item: IHoverInfor; index: number }) => {
    return (
        <Box
            className={`classhover${index}`}
            sx={{
                backgroundColor: '#fff',
                position: 'absolute',
                left: '80%',
                transform: 'translateY(-50%)',
                top: '50%',
                width: '170%',
                maxWidth: '270px',
                zIndex: '10',
                paddingX: '20px',
                paddingTop: '16px',
                paddingBottom: '20px',
                display: 'none',
                flexDirection: 'column',
            }}
        >
            <Typography
                sx={{
                    color: '#1a2023',
                    fontSize: '14px',
                    fontWeight: '700',
                    paddingY: '3.2px',
                    lineHeight: '16.8px',
                    textTransform: 'uppercase',
                }}
            >
                {item.name}
            </Typography>
            <InforList item={item.info} color="#78909c" />
            <Typography
                sx={{
                    color: '#78909c',
                    fontSize: '12px',
                    fontWeight: '300',
                    lineHeight: '18px',
                    paddingBottom: '9.6px',
                }}
            >
                {item.detail}
            </Typography>
            <Box
                sx={{
                    display: 'flex',
                    alignItems: 'center',
                    whiteSpace: 'nowrap',
                    overflow: 'hidden',
                    textOverflow: 'ellipsis',
                }}
            >
                <VideocamIcon sx={{ fontSize: '16px', color: '#b5e745', marginRight: '6.4px' }} />
                <Box
                    sx={{
                        opacity: '0.8',
                        fontSize: '12px',
                        fontWeight: '700',
                        lineHeight: '22px',
                        marginRight: '3px',
                        color: '#78909c',
                    }}
                    component="span"
                >
                    Studio:
                </Box>
                <Box sx={{ fontSize: '12px', fontWeight: '300', lineHeight: '22px', color: '#333' }} component="span">
                    {item.author}
                </Box>
            </Box>
            <Box
                sx={{
                    display: 'flex',
                    alignItems: 'center',
                    whiteSpace: 'nowrap',
                    overflow: 'hidden',
                    textOverflow: 'ellipsis',
                }}
            >
                <MovieIcon sx={{ fontSize: '16px', color: '#b5e745', marginRight: '6.4px' }} />
                <Box
                    sx={{
                        opacity: '0.8',
                        fontSize: '12px',
                        fontWeight: '700',
                        lineHeight: '22px',
                        marginRight: '3px',
                        color: '#78909c',
                    }}
                    component="span"
                >
                    Thể Loại:
                </Box>
                {item.categories.map((category, index) => (
                    <Box
                        key={index}
                        sx={{
                            fontSize: '12px',
                            fontWeight: '300',
                            lineHeight: '22px',
                            textDecoration: 'none',
                            color: '#333',
                            marginRight: '3px',
                        }}
                        component={Link}
                        href={'/'}
                    >
                        {category},
                    </Box>
                ))}
            </Box>
            <Box
                sx={{
                    display: 'flex',
                    alignItems: 'center',
                    whiteSpace: 'nowrap',
                    overflow: 'hidden',
                    textOverflow: 'ellipsis',
                }}
            >
                <PersonIcon sx={{ fontSize: '16px', color: '#b5e745', marginRight: '6.4px' }} />
                <Box
                    sx={{
                        opacity: '0.8',
                        fontSize: '12px',
                        fontWeight: '700',
                        lineHeight: '22px',
                        marginRight: '3px',
                        color: '#78909c',
                    }}
                    component="span"
                >
                    Diễn viên:
                </Box>
                {item.performer.map((per, index) => (
                    <Box
                        key={index}
                        sx={{
                            fontSize: '12px',
                            fontWeight: '300',
                            lineHeight: '22px',
                            textDecoration: 'none',
                            color: '#333',
                            marginRight: '3px',
                        }}
                        component={Link}
                        href={'/'}
                    >
                        {per},
                    </Box>
                ))}
            </Box>
        </Box>
    );
};

export default HoverInfor;
